using Services.cnts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommonLib;
using Services.DAL.Teacher;

namespace Services.svcs
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“TeacherService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 TeacherService.svc 或 TeacherService.svc.cs，然后开始调试。
    public class TeacherService : ITeacherService
    {
        public ReturnState AddTeacherInfo(TeacherInfoView model)
        {
            return TeacherOperator.AddTeacherInfo(model);
        }

        public TeacherInfoView GetTeacherInfo(string email)
        {
            return TeacherOperator.GetTeacherInfo(email);
        }

        public List<TeacherInfoView> GetTeacherInfoList()
        {
            return TeacherOperator.GetTeacherInfoList();
        }

        public bool HasMember(string email)
        {
            return TeacherOperator.HasMember(email);
        }

        public ReturnState RemoveTeacherInfo(string email)
        {
            return TeacherOperator.DelelteTeacherInfo(email) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public ReturnState UpdateTeacherrInfo(TeacherInfoView model)
        {
            return TeacherOperator.UpdateUserInfo(model) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }
    }
}
