﻿using System;
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

        [OperationContract]
        CommonLib.ReturnState RemoveCommentById(int id);

        [OperationContract]
        List<CourseCommentView> GetCommentByCode(string code);

        [OperationContract]
        int GetValidFloor(string code);
    }

    [DataContract]
    public class CourseCommentView
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime PubDate { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember(IsRequired = true)]
        public int Floor { get; set; }
    }
}
