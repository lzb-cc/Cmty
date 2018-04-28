using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml;

namespace UnitTest
{
    class Program
    {
        public static void OpenExcel(string fileName)
        {
            var application = new Application();
            var workBooks = application.Workbooks.Open(fileName);
            var ws = (Worksheet)workBooks.Worksheets["TeacherSets"];
            int rows = ws.UsedRange.Cells.Rows.Count;
            int cols = ws.UsedRange.Columns.Count;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    Console.WriteLine(((Range)ws.Cells[i, j]).Text);
                }
            }

            workBooks.Close();
        }


        public static void ReadJson()
        {
            var path = "tb_datas.txt";
            var reader = new StreamReader(path, Encoding.UTF8);
            var dat = reader.ReadToEnd().Split(';');
            Console.WriteLine(dat[0]);

            var xmlDoc = JsonConvert.DeserializeXmlNode(dat[0], "XmlData").FirstChild;
            var name = xmlDoc.SelectSingleNode("name")?.InnerText;
            var list = xmlDoc.SelectNodes("array");
            foreach(XmlElement node in list)
            {
                Console.WriteLine("{0} {1}", name, node.SelectSingleNode("email")?.InnerText);
            }
        }

        public static void ReadWrite()
        {
            var path = "tt.txt";
            var reader = new StreamReader(path, Encoding.UTF8);
            var data = Convert.FromBase64String(reader.ReadToEnd().Split(',')[1]);
            var fs = new FileStream("tt.jpg", FileMode.Create);
            fs.Write(data, 0, data.Length);
        }

        static void Main(string[] args)
        {
            ReadWrite();
        }
    }
}
