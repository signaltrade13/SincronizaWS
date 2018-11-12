using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SincronizaApp
{
    public partial class _MainForm : Form
    {
        public static readonly string ROOT_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SQLSync");
        public static readonly string SVR_B_FOLDER = Path.Combine(ROOT_FOLDER, "SvrB");
        public static readonly string SVR_C_FOLDER = Path.Combine(ROOT_FOLDER, "SvrC");

        public _MainForm()
        {
            InitializeComponent();
            fswSvrA.Path = SVR_B_FOLDER;
            fswSvrC.Path = SVR_C_FOLDER;
            gvServerB.DataSource = GetElements(GetFiles(SVR_B_FOLDER));
            gvServerC.DataSource = GetElements(GetFiles(SVR_C_FOLDER));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                HideTrayIcon();
                e.Cancel = true;
            }
        }

        private void niApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowTrayIcon();
        }

        public FileInfo[] GetFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            return di.GetFiles("*.sync");
        }

        public List<Element> GetElements(FileInfo[] fls)
        {
            List<Element> res = new List<Element>();

            foreach(var f in fls)
            {
                Element ele = GetElement(f);
                res.Add(ele);
            }

            return res;
        }

        public string GetInfo(string fullname, string accion, string fecha)
        {
            DataTable dt = new DataTable();
            dt.ReadXml(fullname);

            StringBuilder sb = new StringBuilder();

            foreach (DataColumn c in dt.Columns)
                sb.AppendLine($"{c.ColumnName} : {dt.Rows[0][c.ColumnName]}");

            sb.AppendLine($"Accion : {accion}");
            sb.AppendLine($"Fecha : {fecha}");

            return sb.ToString();
        }

        public Element GetElement(FileInfo fi)
        {
            var parts = Path.GetFileNameWithoutExtension(fi.Name).Split('.');

            return new Element
            {
                TableName = parts[0],
                ActionName = parts[2],
                Fecha = fi.CreationTime,
                FullName = fi.FullName
            };
        }

        private void gvServerB_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var action = gvServerB.Rows[e.RowIndex].Cells["Accion"].Value.ToString();
        }

        private void gvServerB_SelectionChanged(object sender, EventArgs e)
        {
            gvServerB.ClearSelection();
        }

        private void gvServerB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var action = gvServerB.Rows[e.RowIndex].Cells["Accion"].Value.ToString();
            var fecha = gvServerB.Rows[e.RowIndex].Cells["Fecha"].Value.ToString();

            var dts = (List<Element>)gvServerB.DataSource;
            gvServerB.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = GetInfo(dts[e.RowIndex].FullName, action, fecha);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTrayIcon();
        }

        private void niApp_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cmNI.Show(MousePosition);
        }

        private void bSyncNow_Click(object sender, EventArgs e)
        {
            var key = ConfigurationManager.AppSettings.Get("UsarWebServices");

            SincroDBService.SincroDBServiceSoapClient clint = new SincroDBService.SincroDBServiceSoapClient();
            //  clint.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://181.123.14.83/SincroDBService.asmx");
            var methods = clint.GetType().GetMethods();

            var dts = (List<Element>)gvServerB.DataSource;
            var element = dts[0];

            MethodInfo method = methods.Where(o => o.ReturnType == typeof(string) && o.Name.Contains(element.TableName)).FirstOrDefault();

            DataTable dt = new DataTable();
            dt.ReadXml(element.FullName);

            List<object> parameter = new List<object>();
            
            foreach (var p in method.GetParameters())
            {
                parameter.Add(dt.Rows[0][p.Name]);
            }

         //   method.Invoke(clint, parameter.ToArray());

            var thread = new Thread(() =>
            {
                for(int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(1000);
                    Invoke(new Action(() =>
                    {
                        lblStatus.Text = i.ToString();
                    }));                    
                }
            });

            thread.Start();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                HideTrayIcon();
        }

        void ShowTrayIcon()
        {
            Visible = true;
            niApp.Visible = false;
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        void HideTrayIcon()
        {
            Visible = false;
            niApp.Visible = true;
        }

        private void fswSvrA_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            ((List<Element>)gvServerB.DataSource).Add(GetElement(new FileInfo(e.FullPath)));
        }

        private void fswSvrC_Created(object sender, FileSystemEventArgs e)
        {

            ((List<Element>)gvServerC.DataSource).Add(GetElement(new FileInfo(e.FullPath)));
        }
    }
}
