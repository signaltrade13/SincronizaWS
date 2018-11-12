using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SincronizaApp
{
    public partial class FormMain : Form
    {
        public static readonly string ROOT_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SQLSync");
        public static readonly string SVR_B_FOLDER = Path.Combine(ROOT_FOLDER, "SvrB");
        public static readonly string SVR_C_FOLDER = Path.Combine(ROOT_FOLDER, "SvrC");
        bool UseWebServiceS1 = false;
        bool UseWebServiceS2 = false;
        string ConnectionStringOrUrlS1 = string.Empty;
        string ConnectionStringOrUrlS2 = string.Empty;

        public FormMain()
        {
            InitializeComponent();

            UseWebServiceS1 = ConfigurationManager.AppSettings.Get("UsarWebServicesS1").Equals("true");
            UseWebServiceS2 = ConfigurationManager.AppSettings.Get("UsarWebServicesS2").Equals("true");
            ConnectionStringOrUrlS1 = ConfigurationManager.AppSettings.Get("ConnectionStringOrUrlS1");
            ConnectionStringOrUrlS2 = ConfigurationManager.AppSettings.Get("ConnectionStringOrUrlS2");

            fswServerB.Path = SVR_B_FOLDER;
            fswServerC.Path = SVR_C_FOLDER;

            gvServidorB.DataSource = Element.Gets(SVR_B_FOLDER);
            gvServidorC.DataSource = Element.Gets(SVR_C_FOLDER);
        }

        private void fswServerB_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            ((BindingList<Element>)gvServidorB.DataSource).Add(Element.Get(new FileInfo(e.FullPath)));
        }

        private void fswServerC_Created(object sender, FileSystemEventArgs e)
        {
            ((BindingList<Element>)gvServidorC.DataSource).Add(Element.Get(new FileInfo(e.FullPath)));
        }

        private void gvServidor_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }

        private void tmrLoop_Tick(object sender, EventArgs e)
        {
            var dsB = (BindingList<Element>)gvServidorB.DataSource;
            var dsC = (BindingList<Element>)gvServidorC.DataSource;
            Thread tB = null;
            Thread tC = null;

            if (dsB.Count > 0)
                tB = SyncServerB(dsB);

            if (dsC.Count > 0)
                tC = SyncServerC(dsC);

            if ((tB == null || !tB.IsAlive) && (tC == null || !tC.IsAlive))
            {
                lblStatus.Text = "";
                bUpdate.Enabled = true;
            }
            else
            {
                bUpdate.Enabled = false;
            }
        }

        Thread SyncServerB(BindingList<Element> items)
        {
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Invoke(new Action(() =>
                    {
                        var ds = (BindingList<Element>)gvServidorB.DataSource;
                        var item = ds.Where(o => o.FullName == items[i].FullName).First();
                        var idx = ds.IndexOf(item);
                        lblStatus.Text = "Syncronizando...";

                        var result = string.Empty;

                        if (UseWebServiceS1)
                        {
                            result = ExecuteWebService(item.FullName, ConnectionStringOrUrlS1);
                        }
                        else
                        {
                            result = ExecuteSqlDirect(item.FullName, ConnectionStringOrUrlS1);
                        }

                        if (result.Equals("Insertado") ||
                            result.Equals("Actualizado") ||
                            result.Equals("Deletado"))
                        {
                            ds.RemoveAt(idx);
                            File.Delete(item.FullName);
                        }

                    }));
                }
            });

            thread.Start();

            return thread;
        }

        Thread SyncServerC(BindingList<Element> items)
        {
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Invoke(new Action(() =>
                    {
                        var ds = (BindingList<Element>)gvServidorC.DataSource;
                        var item = ds.Where(o => o.FullName == items[i].FullName).First();
                        var idx = ds.IndexOf(item);
                        gvServidorC.DataSource = ds;
                        lblStatus.Text = "Syncronizando...";

                        var result = string.Empty;

                        if (UseWebServiceS2)
                        {
                            result = ExecuteWebService(item.FullName, ConnectionStringOrUrlS2);
                        }
                        else
                        {
                            result = ExecuteSqlDirect(item.FullName, ConnectionStringOrUrlS2);
                        }

                        if (result.Equals("Insertado") ||
                        result.Equals("Actualizado") ||
                        result.Equals("Deletado"))
                        {
                            ds.RemoveAt(idx);
                            File.Delete(item.FullName);
                        }

                    }));
                }
            });

            thread.Start();

            return thread;
        }

        string ExecuteSqlDirect(string xmlFile, string ConnectionString)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                return string.Empty;

            SincronizaWS.Metodos.Comandos.ConectionString = ConnectionString;

            var parts = Path.GetFileNameWithoutExtension(xmlFile).Split('.');
            var accion = parts[2];

            DataTable dt = new DataTable();
            dt.ReadXml(xmlFile);

            var method = typeof(SincronizaWS.Metodos.SQLMetodos).GetMethods().Where(o => o.Name.Contains(dt.TableName)).FirstOrDefault();

            if (method == null)
                throw new Exception($"El metodo de la tabla: {dt.TableName}, no encontrado!");

            List<object> args = new List<object>();

            foreach (var p in method.GetParameters())
            {
                if (p.Name.Equals("RowGuid"))
                {
                    var prefix = accion.Equals("Delete") ? "@" : string.Empty;
                    args.Add($"{prefix}{dt.Rows[0][p.Name].ToString()}");
                }
                else
                {
                    if (dt.Columns.Contains(p.Name))
                        args.Add(dt.Rows[0][p.Name]);
                    else
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (String.Compare(p.Name, col.ColumnName, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0)
                            {
                                args.Add(dt.Rows[0][col.ColumnName]);
                            }
                        }
                    }
                }
            }

            return Convert.ToString(method.Invoke(null, args.ToArray()));
        }

        string ExecuteWebService(string xmlFile, string url)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            var parts = Path.GetFileNameWithoutExtension(xmlFile).Split('.');
            var accion = parts[2];

            DataTable dt = new DataTable();
            dt.ReadXml(xmlFile);

            SincroDBService.SincroDBServiceSoapClient client = new SincroDBService.SincroDBServiceSoapClient();
            client.Endpoint.Address = new System.ServiceModel.EndpointAddress(url);

            var method = client.GetType().GetMethods().Where(o => o.ReturnType == typeof(string) && o.Name.Contains(dt.TableName)).FirstOrDefault();

            if (method == null)
                throw new Exception($"El metodo de la tabla: {dt.TableName}, no encontrado!");

            List<object> args = new List<object>();

            foreach (var p in method.GetParameters())
            {

                if (p.Name.Equals("RowGuid"))
                {
                    var prefix = accion.Equals("Delete") ? "@" : string.Empty;
                    args.Add($"{prefix}{dt.Rows[0][p.Name].ToString()}");
                }
                else
                {
                    if (dt.Columns.Contains(p.Name))
                        args.Add(dt.Rows[0][p.Name]);
                    else
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (String.Compare(p.Name, col.ColumnName, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0)
                            {
                                args.Add(dt.Rows[0][col.ColumnName]);
                            }
                        }
                    }
                }
            }

            return Convert.ToString(method.Invoke(client, args.ToArray()));
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                Hide();
                niApp.Visible = true;
                niApp.ShowBalloonTip(5000, "Sincroniza", "La aplicacion esta corriendo", ToolTipIcon.Info);
            }));
        }

        void ShowTray()
        {
            Visible = false;
            niApp.Visible = true;
        }

        void HideTray()
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            BringToFront();
            niApp.Visible = false;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
                e.Cancel = true; ;

            ShowTray();
        }

        private void niApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HideTray();
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                ShowTray();
        }

        private void niApp_BalloonTipClicked(object sender, EventArgs e)
        {
            HideTray();
        }
    }
}
