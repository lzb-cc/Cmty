using Services.cnts;
using Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services.svcs
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UtilityService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UtilityService.svc 或 UtilityService.svc.cs，然后开始调试。
    public class UtilityService : IUtilityService
    {
        public bool AddTeacherCourseMap(string email, string code)
        {
            return UtilityOperator.AddTeacherCourseMap(email, code);
        }

        public bool DelTeacherCourseMap(string email, string code)
        {
            return UtilityOperator.DelTeacherCourseMap(email, code);
        }

        public List<string> GetCourseIdByTeacher(string email)
        {
            return UtilityOperator.GetCourseByTeacher(email);
        }

        public List<string> GetTeacherByCourseId(string code)
        {
            return UtilityOperator.GetTeacherByCourseId(code);
        }

        public int IndexOfJobTitle(string name)
        {
            return UtilityOperator.IndexOfJobTitle(name);
        }

        public int IndexOfUniversity(string university)
        {
            return UtilityOperator.IndexOfUniversity(university);
        }

        public string NameOfJobTitle(int id)
        {
            return UtilityOperator.NameOfJobTitle(id);
        }

        public string NameOfUniversity(int id)
        {
            return UtilityOperator.NameOfUniversity(id);
        }
    }
}
