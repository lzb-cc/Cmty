using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

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
            foreach (XmlElement node in list)
            {
                Console.WriteLine("{0} {1}", name, node.SelectSingleNode("email")?.InnerText);
            }
        }

        public static void ReadWrite()
        {
            var path = "tt.txt";
            var reader = new StreamReader(path, Encoding.UTF8);
            var data = Convert.FromBase64String(reader.ReadToEnd().Split(',')[1]);
            path = "Release";
            var fs = new FileStream(("../" + path + "/" + Guid.NewGuid().ToString() + ".jpg").ToString(), FileMode.Create);
            fs.Write(data, 0, data.Length);
        }

        public static void SendMail()
        {
            var client = new SmtpClient();
            client.Host = "smtp.tom.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("liuzhibin@tom.com", "@qq5201314");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage("liuzhibin@tom.com", "937907891@qq.com");
            message.Subject = "确认注册";
            message.Body = "感谢您好的加入，请<a href='http://localhost:14371/Account/EmailPass?email=937907891@qq.com&&token=1981489905'>点击链接</a>进行验证！";
            message.SubjectEncoding = Encoding.UTF8;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.High;
            message.IsBodyHtml = true;
            client.Send(message);
        }

        public static void WebRequestTest()
        {
            var url = System.Web.HttpUtility.HtmlEncode("http://localhost:14371/Account/EmailPass?email=937907891@qq.com&&token=1981489905");
            var response = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost:8088/Other/SendEmail?sendTo=937907891@qq.com&&subject=请用户注册邮箱验证&content=感谢您好的加入，请点击链接{0}进行验证！", url));
            var val = new StreamReader(response.GetResponse().GetResponseStream()).ReadToEnd();
            var result = Convert.ToInt32(val);
            Console.WriteLine(val);
        }

        public static string Filter(string content, List<string> filters)
        {
            var result = content;
            foreach(var filter in filters)
            {
                result = Regex.Replace(result, filter, "");
            }

            return result;
        }

        static void Main(string[] args)
        {
            var content = "SBHelloCNM";
            var filters = new List<string>();
            filters.Add("SB");
            filters.Add("CNM");
            Console.WriteLine(Filter(content, filters));
        }
    }
}
