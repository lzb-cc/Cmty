using MVCViews.TeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCViews.Svcs
{
    public class TeacherServiceFactory
    {
        private static TeacherService.TeacherService teacherClient = new TeacherService.TeacherService();
        private static bool specify = true;

        public ReturnState AddTeacherInfo(TeacherInfoView model)
        {
            ReturnState result;
            teacherClient.AddTeacherInfo(model, out result, out specify);
            return result;
        }

        public TeacherInfoView GetTeacherInfo(string email)
        {
            return teacherClient.GetTeacherInfo(email);
        }

        public ReturnState UpdateTeacherrInfo(TeacherInfoView model)
        {
            ReturnState result;
            teacherClient.UpdateTeacherrInfo(model, out result, out specify);
            return result;
        }

        public bool HasMember(string email)
        {
            bool result;
            teacherClient.HasMember(email, out result, out specify);
            return result;
        }

        public TeacherInfoView[] GetTeacherInfoList()
        {
            return teacherClient.GetTeacherInfoList();
        }

        public ReturnState RemoveTeacherInfo(string email)
        {
            ReturnState result;
            teacherClient.RemoveTeacherInfo(email, out result, out specify);
            return result;
        }

        public ReturnState AddComment(TeacherCommentView model)
        {
            ReturnState result;
            teacherClient.AddComment(model, out result, out specify);
            return result;
        }

        public ReturnState RemoveComment(TeacherCommentView model)
        {
            ReturnState result;
            teacherClient.RemoveComment(model, out result, out specify);
            return result;
        }

        public TeacherCommentView[] GetCommentByEmail(string email)
        {
            return teacherClient.GetCommentByEmail(email);
        }

        public int GetValidFloor(string code)
        {
            int result;
            teacherClient.GetValidFloor(code, out result, out specify);
            return result;
        }
    }
}