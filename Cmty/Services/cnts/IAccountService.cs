﻿using System;
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
        CommonLib.ReturnState Register(RegisterView model);

        // TODO: 在此添加您的服务操作
        [OperationContract]
        CommonLib.ReturnState Login(LoginView model);

        [OperationContract]
        int IndexOfUniversity(string university);

        [OperationContract]
        UserInfoView GetUserInfo(string email);

        [OperationContract]
        CommonLib.ReturnState UpdateUserInfo(UserInfoView model);
    }

    [DataContract]
    public class RegisterView
    {
        private string _email;
        private string _password;
        private int _userType;
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

        [DataMember]
        public int UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        [DataMember]
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
    }
}
