using Services.cnts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommonLib;
using Services.DAL.Course;

namespace Services.svcs
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CourseService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CourseService.svc 或 CourseService.svc.cs，然后开始调试。
    public class CourseService : ICourseService
    {
        public ReturnState AddCourse(CourseView model)
        {
            if (CourseOperator.HasMember(model.Code))
                return ReturnState.ReturnError;
            return CourseOperator.AddCourse(model);
        }

        public ReturnState AddCourseApply(CourseView model, UserApply user)
        {
            return CourseOperator.AddCourseApply(model, user) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public List<CourseView> GetCourseByPage(int page, int nPage = 10)
        {
            return CourseOperator.GetCourseByPage(page, nPage);
        }

        public List<CourseReviewView> GetCourseReviews()
        {
            return CourseOperator.GetCourseReviewViews();
        }

        public List<CourseReviewView> GetCourseReviewViewByEmail(string email)
        {
            return CourseOperator.GetCourseReviewViewByEmail(email);
        }

        public bool HasMember(string code)
        {
            return CourseOperator.HasMember(code);
        }

        public ReturnState ReviewPass(string code)
        {
            return CourseOperator.ReviewPass(code) ? CommonLib.ReturnState.ReturnOK : CommonLib.ReturnState.ReturnError;
        }
    }
}
