using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IAccountService”。
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        void RegisterWithoutValid(RegisterView model);

        [OperationContract]
        CommonLib.ReturnState Register(RegisterView model);

        // TODO: 在此添加您的服务操作
        [OperationContract]
        CommonLib.ReturnState Login(LoginView model);

        [OperationContract]
        UserInfoView GetUserInfo(string email);

        [OperationContract]
        CommonLib.ReturnState UpdateUserInfo(UserInfoView model);

        [OperationContract]
        CommonLib.ReturnState AdminLogin(LoginView model);

        [OperationContract]
        bool HasMember(string email);

        [OperationContract]
        bool IsEmailValid(string email);

        [OperationContract]
        bool SetEamilStatus(string email, int token);

        [OperationContract]
        int GetEmailCheckStatus(string email);

        [OperationContract]
        void ReValidEmail(string email);

        [OperationContract]
        void DeleteUser(string email);

        [OperationContract]
        void CheckEmailForDelete(string email);

        [OperationContract]
        void AddForgotPassword(ForgotPasswordView model);

        [OperationContract]
        void UpdateForgotPassword(int id, int status);

        [OperationContract]
        void DeleteForgotPassword(int id);

        [OperationContract]
        List<ForgotPasswordView> GetForgotPasswordList();

        [OperationContract]
        ForgotPasswordView GetForgotPasswordById(int id);

        [OperationContract]
        void UpdateUserPassword(string email, string password);
    }

    [DataContract]
    public class RegisterView
    {
        private string _email;
        private string _password;
        private string _userName;
        private string _tel;
        private int _university;

        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [DataMember]
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        [DataMember(IsRequired = true)]
        public int University
        {
            get { return _university; }
            set { _university = value; }
        }
    }

    [DataContract]
    public class LoginView
    {
        private string _email;
        private string _password;

        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }

    [DataContract]
    public class UserInfoView
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Tel { get; set; }

        [DataMember]
        public string University { get; set; }

        [DataMember]
        public string Sex { get; set; }

        [DataMember]
        public string Nick { get; set; }

        [DataMember]
        public string Hobby { get; set; }

        [DataMember]
        public string Avatar { get; set; }
    }

    public class ForgotPasswordView
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public string Email { get; set; }

        [DataMember(IsRequired = true)]
        public string UserName { get; set; }

        [DataMember(IsRequired = true)]
        public string Sex { get; set; }

        [DataMember(IsRequired = true)]
        public string Nick { get; set; }

        [DataMember(IsRequired = true)]
        public string Tel { get; set; }

        [DataMember(IsRequired =true)]
        public DateTime Date { get; set; }

        [DataMember(IsRequired = true)]
        public int Status { get; set; }
    }
}
