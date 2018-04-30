using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Admin.Svcs
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“AdminServices”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 AdminServices.svc 或 AdminServices.svc.cs，然后开始调试。
    public class AdminServices : IAdminServices
    {
        public static string userName = ConfigurationManager.ConnectionStrings["userName"].ConnectionString;
        public static string password = ConfigurationManager.ConnectionStrings["password"].ConnectionString;

        // 如果出错，就是没有配置 Web.config of userName and password
        public void SendEamil(string sendTo, string subject, string content)
        {
            var client = new SmtpClient();
            client.Host = "smtp.tom.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(userName, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage(userName, sendTo);
            message.Subject = subject;
            message.Body = content;
            message.SubjectEncoding = Encoding.UTF8;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.High;
            message.IsBodyHtml = true;
            
            try
            {
                client.Send(message);
            }
            //catch (Exception) { }
            finally
            {
                client.Dispose();
            }
        }
    }
}
