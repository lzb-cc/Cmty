using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services.cnts
{
    [ServiceContract]
    public interface IUtilityService
    {
        [OperationContract]
        int IndexOfUniversity(string university);

        [OperationContract]
        string NameOfUniversity(int id);

        [OperationContract]
        int IndexOfJobTitle(string name);

        [OperationContract]
        string NameOfJobTitle(int id);

        [OperationContract]
        bool AddTeacherCourseMap(string email, string code);

        [OperationContract]
        bool DelTeacherCourseMap(string email, string code);

        [OperationContract]
        List<string> GetCourseIdByTeacher(string email);

        [OperationContract]
        List<string> GetTeacherByCourseId(string code);

        [OperationContract]
        string NameOfCourse(string code);
    }
}
