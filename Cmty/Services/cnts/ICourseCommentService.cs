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
    interface ICourseCommentService
    {
        [OperationContract]
        CommonLib.ReturnState AddComment(CourseCommentView model);

        [OperationContract]
        CommonLib.ReturnState RemoveComment(CourseCommentView model);
    }

    [DataContract]
    public class CourseCommentView
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime PubDate { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int Floor { get; set; }
    }
}
