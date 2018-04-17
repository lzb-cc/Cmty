using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop.Excel;

namespace Admin.Controllers
{
    public class OtherController : AuthorityController
    {
        private static Application application = new Application();
        private Workbook workBook;
        private const string url = "http://localhost:8090/";

        // GET: Other
        public ActionResult Index()
        {
            return View();
        }

        public void SetUserSets()
        {
            var ws = (Worksheet)workBook.Worksheets["UserSets"];
            int rows = ws.UsedRange.Cells.Rows.Count;

            for (int i = 1; i <= rows; i++)
            {
                var model = new AccountService.RegisterView()
                {
                    Email = ((Range)ws.Cells[i, 1]).Text,
                    Password = ((Range)ws.Cells[i, 2]).Text,
                    UserName = ((Range)ws.Cells[i, 3]).Text,
                    Tel = ((Range)ws.Cells[i, 4]).Text,
                    University = Convert.ToInt32(((Range)ws.Cells[i, 5]).Text)
                };
                accountClient.Register(model);
            }
        }

        public void SetTeacherSets()
        {
            var ws = (Worksheet)workBook.Worksheets["TeacherSets"];
            int rows = ws.UsedRange.Cells.Rows.Count;

            for (int i = 1; i <= rows; i++)
            {
                var model = new TeacherService.TeacherInfoView()
                {
                    Email = ((Range)ws.Cells[i, 1]).Text,
                    UserName = ((Range)ws.Cells[i, 2]).Text,
                    RegisteDate = Convert.ToDateTime(((Range)ws.Cells[i, 3]).Text),
                    Tel = ((Range)ws.Cells[i,4]).Text,
                    University = Convert.ToInt32(((Range)ws.Cells[i, 5]).Text),
                    Sex = ((Range)ws.Cells[i, 6]).Text,
                    JobTitle = Convert.ToInt32(((Range)ws.Cells[i, 7]).Text),
                    Desp = ((Range)ws.Cells[i, 8]).Text
                };
                teacherClient.AddTeacherInfo(model);
            }
        }

        public ActionResult UploadData(string fileName)
        {
            workBook = application.Workbooks.Open(Url + fileName);
            workBook.Close();
            return RedirectToAction("Index");
        }
    }
}