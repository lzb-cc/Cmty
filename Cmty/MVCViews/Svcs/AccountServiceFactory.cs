using MVCViews.AccountService;

namespace MVCViews.Svcs
{
    public class AccountServiceFactory
    {

        private static AccountService.AccountService accountClient = new AccountService.AccountService();
        private static bool specify = false;

        public ReturnState Register(RegisterView model)
        {
            ReturnState outResult;
            accountClient.Register(model, out outResult, out specify);
            return outResult;
        }

        public bool Login(LoginView model)
        {
            ReturnState outResult;
            accountClient.Login(model, out outResult, out specify);
            return outResult == ReturnState.ReturnOK;
        }


        public UserInfoView GetUserInfo(string email)
        {
            return accountClient.GetUserInfo(email);
        }

        public ReturnState UpdateUserInfo(UserInfoView model)
        {
            ReturnState outResult;
            accountClient.UpdateUserInfo(model, out outResult, out specify);
            return outResult;
        }

        public ReturnState AdminLogin(LoginView model)
        {
            ReturnState outResult;
            accountClient.AdminLogin(model, out outResult, out specify);
            return outResult;
        }

        public bool HasMember(string email)
        {
            bool outResult;
            accountClient.HasMember(email, out outResult, out specify);
            return outResult;
        }

        public bool IsEmailValid(string email)
        {
            bool outResult;
            accountClient.IsEmailValid(email, out outResult, out specify);
            return outResult;
        }

        public bool SetEamilStatus(string email, int token)
        {
            bool outResult;
            accountClient.SetEamilStatus(email, token, specify, out outResult, out specify);
            return outResult;
        }

        public bool GetEmailCheckStatus(string email)
        {
            bool outResult;
            accountClient.HasMember(email, out outResult, out specify);
            return outResult;
        }

        public void ReValidEmail(string email)
        {
            accountClient.ReValidEmail(email);
        }

        public void DeleteUser(string email)
        {
            accountClient.DeleteUser(email);
        }

        public void SendEmailForDelete(string email)
        {
            accountClient.CheckEmailForDelete(email);
        }

        public void AddForgotPasswordApply(ForgotPasswordView model)
        {
            accountClient.AddForgotPassword(model);
        }

        public void UpdateUserPassword(string email, string password)
        {
            accountClient.UpdateUserPassword(email, password);
        }
    }
}