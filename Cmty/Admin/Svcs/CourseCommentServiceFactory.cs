using Admin.CourseCommentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Svcs
{
    public class CourseCommentServiceFactory
    {
        private static CourseCommentService.CourseCommentService courseCommentClient = new CourseCommentService.CourseCommentService();
        private static bool specify = false;

        public ReturnState AddComment(CourseCommentView model)
        {
            ReturnState result;
            courseCommentClient.AddComment(model, out result, out specify);
            return result;   
        }

        public ReturnState RemoveComment(CourseCommentView model)
        {
            ReturnState result;
            courseCommentClient.RemoveComment(model, out result, out specify);
            return result;
        }

        public ReturnState RemoveCommentById(int id)
        {
            ReturnState result;
            courseCommentClient.RemoveCommentById(id, specify, out result, out specify);
            return result;
        }

        public CourseCommentView[] GetCommentByCode(string code)
        {
            return courseCommentClient.GetCommentByCode(code);
        }

        public int GetValidFloor(string code)
        {
            int result;
            courseCommentClient.GetValidFloor(code, out result, out specify);
            return result;
        }
    }
}