using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services.cnts
{
    [ServiceContract]
    public interface ICourseService
    {
        [OperationContract]
        CommonLib.ReturnState AddCourse(CourseView model);

        [OperationContract]
        List<CourseView> GetCourseByPage(int page, int nPage);
    }

    [DataContract]
    public class CourseView
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public int University { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Desp { get; set; }

        [DataMember]
        public string PicUrl { get; set; }
    }

    [DataContract]
    public class UserApply
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime CommitDate { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
