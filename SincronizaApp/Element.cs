using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincronizaApp
{
    public class Element
    {
        public string TableName { get; set; }
        public string ActionName { get; set; }
        public DateTime Fecha { get; set; }
        [Browsable(false)]
        public string FullName { get; set; }

        public static Element Get(FileInfo fi)
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

        public static BindingList<Element> Gets(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            var files = di.GetFiles("*.sync");

            BindingList<Element> res = new BindingList<Element>();

            foreach (var file in files)
            {
                Element ele = Get(file);
                res.Add(ele);
            }

            return res;
        }

        public static string GetInfo(string fullname)
        {
            var parts = Path.GetFileNameWithoutExtension(fullname).Split('.');
            var table = parts[0];
            var accion = parts[2];

            DataTable dt = new DataTable();
            dt.ReadXml(fullname);

            StringBuilder sb = new StringBuilder();

            foreach (DataColumn c in dt.Columns)
                sb.AppendLine($"{c.ColumnName} : {dt.Rows[0][c.ColumnName]}");

            sb.AppendLine($"Accion : {accion}");
            sb.AppendLine($"Fecha : {new FileInfo(fullname).CreationTime}");

            return sb.ToString();
        }
    }
}
