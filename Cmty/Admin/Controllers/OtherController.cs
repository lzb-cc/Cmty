using System;
using System.Web.Mvc;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace Admin.Controllers
{
    public class OtherController : AuthorityController
    {
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

        public void SetUserSets(XmlNodeList nodeList)
        {
            foreach (XmlElement node in nodeList)
            {
                var model = new AccountService.RegisterView();
                model.Email = node.SelectSingleNode("email")?.InnerText;
                model.Password = node.SelectSingleNode("password")?.InnerText;
                model.UserName = node.SelectSingleNode("name")?.InnerText;
                model.Tel = node.SelectSingleNode("tel")?.InnerText;
                model.University = Convert.ToInt32(node.SelectSingleNode("university")?.InnerText);
                if (accountClient.HasMember(model.Email))
                {
                    continue;
                }

                accountClient.Register(model);
            }
        }

        public void SetTeacherSets(XmlNodeList nodeList)
        {
            foreach (XmlElement node in nodeList)
            {
                var model = new TeacherService.TeacherInfoView();
                model.Email = node.SelectSingleNode("email")?.InnerText;
                model.UserName = node.SelectSingleNode("name")?.InnerText;
                model.RegisteDate = Convert.ToDateTime(node.SelectSingleNode("date")?.InnerText);
                model.Tel = node.SelectSingleNode("tel")?.InnerText;
                model.University = Convert.ToInt32(node.SelectSingleNode("university")?.InnerText);
                model.Sex = node.SelectSingleNode("sex")?.InnerText;
                model.JobTitle = Convert.ToInt32((node.SelectSingleNode("title")?.InnerText));
                model.Desp = node.SelectSingleNode("desp")?.InnerText;
                if (teacherClient.HasMember(model.Email))
                {
                    continue;
                }
                teacherClient.AddTeacherInfo(model);
            }
        }

        public void SetCourseSets(XmlNodeList nodeList)
        {
            foreach (XmlElement node in nodeList)
            {
                var model = new CourseService.CourseView();
                model.Code = node.SelectSingleNode("code")?.InnerText;
                model.University = Convert.ToInt32((node.SelectSingleNode("university")?.InnerText));
                model.Name = node.SelectSingleNode("name")?.InnerText;
                model.Desp = node.SelectSingleNode("desp")?.InnerText;
                model.PicUrl = node.SelectSingleNode("url")?.InnerText;
                if (courseClient.HasMember(model.Code))
                {
                    continue;
                }

                courseClient.AddCourse(model);
            }
        }

        public void SetTeacherCourseSets(XmlNodeList nodeList)
        {
            foreach (XmlElement node in nodeList)
            {
                var email = node.SelectSingleNode("email").InnerText;
                var code = node.SelectSingleNode("code").InnerText;
                utilityClient.DelTeacherCourseMap(email, code);
                utilityClient.AddTeacherCourseMap(email, code);
            }
        }

        public void SetGoodsInfoSets(XmlNodeList nodeList)
        {
            foreach (XmlElement node in nodeList)
            {
                var model = new MarketService.GoodsInfo();
                model.Seller = node.SelectSingleNode("seller")?.InnerText;
                model.Name = node.SelectSingleNode("name")?.InnerText;
                model.Money = Convert.ToInt32(node.SelectSingleNode("price")?.InnerText);
                model.PicUrl = node.SelectSingleNode("url")?.InnerText;
                model.Desp = node.SelectSingleNode("desp")?.InnerText;
                model.AddDate = Convert.ToDateTime(node.SelectSingleNode("date")?.InnerText);
                model.Status = node.SelectSingleNode("status")?.InnerText;
                model.Buyer = node.SelectSingleNode("buyer")?.InnerText;
                model.Comments = node.SelectSingleNode("comments")?.InnerText;
                model.Type = node.SelectSingleNode("type")?.InnerText;

                if (marketClient.HasMember(model))
                {
                    continue;
                }
                marketClient.UserAddGoods(model);
            }
        }

        public void SetPostMsgSets(XmlNodeList nodeList)
        {
            foreach (XmlElement node in nodeList)
            {
                var model = new ForumService.PostModel();
                model.Poster = node.SelectSingleNode("poster")?.InnerText;
                model.Title = node.SelectSingleNode("title")?.InnerText;
                model.PostType = node.SelectSingleNode("type")?.InnerText;
                model.Content = node.SelectSingleNode("content")?.InnerText;
                model.PublishDate = Convert.ToDateTime(node.SelectSingleNode("date")?.InnerText);
                model.NoComments = Convert.ToInt32(node.SelectSingleNode("NoComments")?.InnerText);
                forumClient.AddPost(model);
            }
        }

        public ActionResult UploadData(string fileName)
        {
            var msg = "导入成功!";
            {
                var jsonList = new StreamReader(((HttpWebRequest)WebRequest.Create((url + fileName).ToString())).GetResponse().GetResponseStream()).ReadToEnd().Split(';');
                foreach (var json in jsonList)
                {
                    var node = JsonConvert.DeserializeXmlNode(json, "json").FirstChild;
                    var name = node.SelectSingleNode("name")?.InnerText;
                    if (string.IsNullOrEmpty(name))
                    {
                        break;
                    }

                    if (name.Equals("UserSets"))
                    {
                        SetUserSets(node.SelectNodes("array"));
                    }

                    if (name.Equals("TeacherSets"))
                    {
                        SetTeacherSets(node.SelectNodes("array"));
                    }

                    if (name.Equals("CourseSets"))
                    {
                        SetCourseSets(node.SelectNodes("array"));
                    }

                    if (name.Equals("TeacherCourseSets"))
                    {
                        SetTeacherCourseSets(node.SelectNodes("array"));
                    }

                    if (name.Equals("GoodsInfoSets"))
                    {
                        SetGoodsInfoSets(node.SelectNodes("array"));
                    }

                    if(name.Equals("PostMsg"))
                    {
                        SetPostMsgSets(node.SelectNodes("array"));
                    }
                }
            }

            ViewBag.Msg = msg;
            return RedirectToAction("Index", "Other", new { msg = msg });
        }
    }
}