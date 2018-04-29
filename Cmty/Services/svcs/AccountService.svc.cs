using System;
using Services.DAL.Account;
using System.Net;
using System.IO;
using System.Threading;

namespace Services
{
    public class AccountService : IAccountService
    {
        private void SendEmailForRegister(object objEmail)
        {
            var email = objEmail as string;
            var token = AccountOperator.GetEmailToken(email);
            var checkLink = string.Format("http://localhost:14371/Account/EmailPass?email={0}&&token={1}", email, token);
            var url = string.Format("http://localhost:8088/Other/SendEmail?sendTo={0}&&subject=请用户注册邮箱验证&content=感谢您好的加入，请点击链接{1}进行验证！", email, checkLink);
            Convert.ToInt32(new StreamReader(((HttpWebRequest)WebRequest.Create(url)).GetResponse().GetResponseStream()).ReadToEnd());
        }

        public CommonLib.ReturnState Register(RegisterView model)
        {
            var result = CommonLib.ReturnState.ReturnOK;
            if (AccountOperator.HasMember(model.Email))
                result =  CommonLib.ReturnState.ReturnError;
            result = AccountOperator.Register(model);
            result = AccountOperator.AddEmailToCheckSet(model.Email) ? CommonLib.ReturnState.ReturnOK : CommonLib.ReturnState.ReturnError;
            if(result.Equals(CommonLib.ReturnState.ReturnOK))
            {
                var thread = new Thread(new ParameterizedThreadStart(this.SendEmailForRegister));
                thread.Start(model.Email);
            }

            return result;
        }

        public CommonLib.ReturnState Login(LoginView model)
        {
            return AccountOperator.Login(model) ? CommonLib.ReturnState.ReturnOK : CommonLib.ReturnState.ReturnError;
        }

        public UserInfoView GetUserInfo(string email)
        {
            return AccountOperator.GetUserInfo(email);
        }

        public CommonLib.ReturnState UpdateUserInfo(UserInfoView model)
        {
            if (!AccountOperator.HasMember(model.Email))
                return CommonLib.ReturnState.ReturnError;
            return AccountOperator.UpdateUserInfo(model) ? CommonLib.ReturnState.ReturnOK : CommonLib.ReturnState.ReturnError;
        }

        public CommonLib.ReturnState AdminLogin(LoginView model)
        {
            return AccountOperator.AdminLogin(model) ? CommonLib.ReturnState.ReturnOK : CommonLib.ReturnState.ReturnError;
        }

        public bool HasMember(string email)
        {
            return AccountOperator.HasMember(email);
        }

        public bool IsEmailValid(string email)
        {
            return AccountOperator.IsEmailValid(email);
        }

        public bool SetEamilStatus(string email, int token)
        {
            return AccountOperator.SetEmailStatus(email, token);
        }
    }
}
