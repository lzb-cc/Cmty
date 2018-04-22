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

        [HttpPost]
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
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
                if (accountClient.HasMember(model.Email))
                {
                    continue;
                }

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
                    Tel = ((Range)ws.Cells[i, 4]).Text,
                    University = Convert.ToInt32(((Range)ws.Cells[i, 5]).Text),
                    Sex = ((Range)ws.Cells[i, 6]).Text,
                    JobTitle = Convert.ToInt32(((Range)ws.Cells[i, 7]).Text),
                    Desp = ((Range)ws.Cells[i, 8]).Text
                };
                if (teacherClient.HasMember(model.Email))
                {
                    continue;
                }
                teacherClient.AddTeacherInfo(model);
            }
        }

        public void SetCourseSets()
        {
            var ws = (Worksheet)workBook.Worksheets["CourseSets"];
            int rows = ws.UsedRange.Cells.Rows.Count;

            for (int i = 1; i <= rows; i++)
            {
                var model = new CourseService.CourseView()
                {
                    Code = ((Range)ws.Cells[i, 1]).Text,
                    University = Convert.ToInt32(((Range)ws.Cells[i, 2]).Text),
                    Name = ((Range)ws.Cells[i, 3]).Text,
                    Desp = ((Range)ws.Cells[i, 4]).Text,
                    PicUrl = ((Range)ws.Cells[i, 5]).Text
                };
                if (courseClient.HasMember(model.Code))
                {
                    continue;
                }

                courseClient.AddCourse(model);
            }
        }

        public void SetTeacherCourseSets()
        {
            var ws = (Worksheet)workBook.Worksheets["TeacherCourseSets"];
            int rows = ws.UsedRange.Cells.Rows.Count;

            for (int i = 1; i <= rows; i++)
            {
                utilityClient.DelTeacherCourseMap(((Range)ws.Cells[i, 1]).Text, ((Range)ws.Cells[i, 2]).Text);
                utilityClient.AddTeacherCourseMap(((Range)ws.Cells[i, 1]).Text, ((Range)ws.Cells[i, 2]).Text);
            }
        }

        public void SetGoodsInfoSets()
        {
            var ws = (Worksheet)workBook.Worksheets["GoodsInfoSets"];
            int rows = ws.UsedRange.Cells.Rows.Count;

            for (int i = 1; i <= rows; i++)
            {
                var model = new MarketService.GoodsInfo()
                {
                    Seller = ((Range)ws.Cells[i, 1]).Text,
                    Name = ((Range)ws.Cells[i, 2]).Text,
                    Money = Convert.ToInt32(((Range)ws.Cells[i, 3]).Text),
                    PicUrl = ((Range)ws.Cells[i, 4]).Text,
                    Desp = ((Range)ws.Cells[i, 5]).Text,
                    AddDate = Convert.ToDateTime(((Range)ws.Cells[i, 6]).Text),
                    Status = ((Range)ws.Cells[i, 7]).Text,
                    Buyer = ((Range)ws.Cells[i, 8]).Text,
                    Comments = ((Range)ws.Cells[i, 9]).Text,
                    Type = ((Range)ws.Cells[i, 10]).Text
                };

                if (marketClient.HasMember(model))
                {
                    continue;
                }
                marketClient.UserAddGoods(model);
            }
        }

        public ActionResult UploadData(string fileName)
        {
            var msg = "导入成功!";
            //try
            {
                workBook = application.Workbooks.Open((fileName).ToString());
                SetUserSets();
                SetCourseSets();
                SetTeacherSets();
                SetTeacherCourseSets();
                SetGoodsInfoSets();
            }
            //catch (Exception e)
            {
            //    msg = e.Message;
            }
            //finally
            {
                if (workBook != null)
                {
                    workBook.Close();
                }
            }

            ViewBag.Msg = msg;
            return RedirectToAction("Index", "Other", new { msg = msg });
        }
    }
}