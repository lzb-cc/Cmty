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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CourseCommentService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CourseCommentService.svc 或 CourseCommentService.svc.cs，然后开始调试。
    public class CourseCommentService : ICourseCommentService
    {
        public ReturnState AddComment(CourseCommentView model)
        {
            var filters = new UtilityService().GetFilterLisst();
            model.Content = Utilities.Filter(model.Content, filters);
            return CourseCommentOperator.AddCourseComment(model) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public List<CourseCommentView> GetCommentByCode(string code)
        {
            return CourseCommentOperator.GetCourseCommentListByCode(code);
        }

        public int GetValidFloor(string code)
        {
            return CourseCommentOperator.GetValidFloor(code);
        }

        public ReturnState RemoveComment(CourseCommentView model)
        {
            return CourseCommentOperator.RemoveCourseComment(model) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public ReturnState RemoveCommentById(int id)
        {
            return CourseCommentOperator.RemoveCourseCommentById(id) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }
    }
}
