﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Services.DAL.Account;
using Services.DAL;

namespace Services
{
    public class AccountService : IAccountService
    {
        public CommonLib.ReturnState Register(RegisterView model)
        {
            if (AccountOperator.HasMember(model.Email))
                return CommonLib.ReturnState.ReturnError;
            return AccountOperator.Register(model);
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
    }
}
