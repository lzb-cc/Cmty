﻿using System;
using Services.DAL.Account;
using System.Net;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace Services
{
    public class AccountService : IAccountService
    {
        private static AdminService.AdminServices adminClient = new AdminService.AdminServices();
        private static AdminServiceTest.AdminServicesClient adminTestClient = new AdminServiceTest.AdminServicesClient();

        private void SendEmailForRegister(object objEmail)
        {
            var email = objEmail as string;
            var token = AccountOperator.GetEmailToken(email);
            var checkLink = string.Format("http://localhost:8070/Account/EmailPass?email={0}&&token={1}", email, token);
            var subject = "Thanks for joining.";
            var content = string.Format("Thank you for join us, please <a href = '{0}'>click me</a> to finish the validation.", checkLink);
            adminClient.SendEamil(email, subject, content);
        }

        private void SendEmailForDelete(object objEmail)
        {
            var email = objEmail as string;
            var checkLink = string.Format("http://localhost:8070/Account/ConfirmDelete?email={0}", email);
            var subject = "confirm to delete your account.";
            var content = string.Format("Thank you for join us, please <a href = '{0}'>click me</a> to finish the validation.", checkLink);
            adminClient.SendEamil(email, subject, content);
        }

        public CommonLib.ReturnState Register(RegisterView model)
        {
            var result = CommonLib.ReturnState.ReturnOK;
            if (AccountOperator.HasMember(model.Email))
                result = CommonLib.ReturnState.ReturnError;
            result = AccountOperator.Register(model);
            result = AccountOperator.AddEmailToCheckSet(model.Email) ? CommonLib.ReturnState.ReturnOK : CommonLib.ReturnState.ReturnError;
            if (result.Equals(CommonLib.ReturnState.ReturnOK))
            {
                SendEmailForRegister(model.Email);
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

        public int GetEmailCheckStatus(string email)
        {
            return AccountOperator.GetEmailCheckStatus(email);
        }

        public void ReValidEmail(string email)
        {
            SendEmailForRegister(email);
        }

        public void DeleteUser(string email)
        {
            AccountOperator.DeleteUser(email);
        }

        public void CheckEmailForDelete(string email)
        {
            SendEmailForDelete(email);
        }

        public void AddForgotPassword(ForgotPasswordView model)
        {
            AccountOperator.ForgotPasswordApply(model);
        }

        private void SendEmailForForgotPass(string email)
        {
            var checkLink = string.Format("http://localhost:8070/Account/ModifyPassword?email={0}", email);
            var subject = "Result for forgot password apply.";
            var content = string.Format("Please <a href = '{0}'>click me</a> to Reset the password.", checkLink);
            adminClient.SendEamil(email, subject, content);
        }

        private void SendEmailForForgotFailed(string email)
        {
            var subject = "Result for forgot password apply.";
            var content = string.Format("I'm sorry to inform you that your apply failed.");
            adminClient.SendEamil(email, subject, content);
        }

        public void UpdateForgotPassword(int id, int status)
        {
            var email = GetForgotPasswordById(id).Email;
            if (status == 1)
            {
                SendEmailForForgotPass(email);
            }
            else if (status == 2)
            {
                SendEmailForForgotFailed(email);
            }
            AccountOperator.UpdateForgotPasswordStatus(id, status);
        }

        public void DeleteForgotPassword(int id)
        {
            AccountOperator.DeleteForgotPassword(id);
        }

        public List<ForgotPasswordView> GetForgotPasswordList()
        {
            return AccountOperator.GetForgotPasswordList();
        }

        public ForgotPasswordView GetForgotPasswordById(int id)
        {
            return AccountOperator.GetForgotPasswordById(id);
        }

        public void UpdateUserPassword(string email, string password)
        {
            AccountOperator.UpdateUserPassword(email, password);
        }

        public void RegisterWithoutValid(RegisterView model)
        {
            AccountOperator.Register(model);
        }
    }
}
