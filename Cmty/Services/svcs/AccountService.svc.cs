using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Services.DAL.Account;

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

        public int IndexOfUniversity(string university)
        {
            return AccountOperator.IndexOfUniversity(university);
        }
    }
}
