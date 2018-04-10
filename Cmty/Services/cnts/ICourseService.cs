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

        [OperationContract]
        CommonLib.ReturnState AddCourseApply(CourseView model, UserApply user);

        [OperationContract]
        bool HasMember(string code);

        [OperationContract]
        List<CourseReviewView> GetCourseReviewViewByEmail(string email);

        [OperationContract]
        List<CourseReviewView> GetCourseReviews();

        [OperationContract]
        CommonLib.ReturnState ReviewPass(string code);

        [OperationContract]
        CommonLib.ReturnState ReviewFailed(string code);

        [OperationContract]
        CourseView GetCourseByCode(string code);
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
        public int Status { get; set; }
    }

    public class CourseReviewView
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string University { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Desp { get; set; }

        [DataMember]
        public string PicUrl { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime CommitDate { get; set; }

        [DataMember]
        public string Status { get; set; }

    }
}
