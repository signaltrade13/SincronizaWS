using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var RowGuid = "@a3339163-4d75-4928-b56e-a3f5c17c7059";
            var Delete = RowGuid.Substring(0,1);

            int nameLength = RowGuid.Length;

            RowGuid = RowGuid.Substring(1, RowGuid.Length -1);

            Console.WriteLine("Pametro Pasado : ", RowGuid.ToString());
            Console.WriteLine("Caracter Del Pasado : ", Delete.ToString());
            Console.WriteLine("RowGuidLimpio Pasado : ", RowGuid.ToString());

            Console.ReadKey();


        }
    }
}
