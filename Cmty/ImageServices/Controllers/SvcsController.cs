using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ImageServices.Controllers
{
    class Resp
    {
        public int Status { get; set; }
        public string FileName { get; set; }
    }

    public class SvcsController : Controller
    {

        // GET: Svcs
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadFile(string base64Data)
        {
            var img = Convert.FromBase64String(base64Data);
            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var fs = new FileStream((Server.MapPath("~/ImageUrl/") + fileName).ToString(), FileMode.Create);
            fs.Write(img, 0, img.Length);
            fs.Close();
            return Json(new Resp
            {
                Status = 0,
                FileName = fileName,
            });
        }
    }
}