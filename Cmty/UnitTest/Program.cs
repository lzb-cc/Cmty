using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




        static void Main(string[] args)
        {
            OpenExcel("http://localhost:8090/tb_datas.xlsx");
        }
    }
}
