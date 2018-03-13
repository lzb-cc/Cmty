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
        CommonLib.ReturnState Register(RegisterView register);

        // TODO: 在此添加您的服务操作
    }

    [DataContract]
    public class RegisterView
    {
        private string _email;
        private string _password;
        private int _userType;
        private string _userName;
        private string _tel;

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
    }
}