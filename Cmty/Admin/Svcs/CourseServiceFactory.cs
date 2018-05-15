using Admin.CourseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Svcs
{
    public class CourseServiceFactory
    {
        private static CourseService.CourseService courseClient = new CourseService.CourseService();
        private static bool specify = true;

        public ReturnState AddCourse(CourseView model)
        {
            ReturnState result;
            courseClient.AddCourse(model, out result, out specify);
            return result;
        }
        public CourseView[] GetCourseByPage(int page, int nPage)
        {
            return courseClient.GetCourseByPage(page, specify, nPage, specify);
        }

        public bool AddCourseApply(CourseView model, UserApply user)
        {
            ReturnState result;
            courseClient.AddCourseApply(model, user, out result, out specify);
            return result == ReturnState.ReturnOK;
        }

        public bool HasMember(string code)
        {
            bool result;
            courseClient.HasMember(code, out result, out specify);
            return result;
        }

        public CourseReviewView[] GetCourseReviewViewByEmail(string email)
        {
            return courseClient.GetCourseReviewViewByEmail(email);
        }

        public CourseReviewView[] GetCourseReviews()
        {
            return courseClient.GetCourseReviews();
        }

        public ReturnState ReviewPass(string code)
        {
            ReturnState result;
            courseClient.ReviewPass(code, out result, out specify);
            return result;
        }

        public ReturnState ReviewFailed(string code)
        {
            ReturnState result;
            courseClient.ReviewFailed(code, out result, out specify);
            return result;
        }

        public CourseView GetCourseByCode(string code)
        {
            return courseClient.GetCourseByCode(code);
        }
    }
}