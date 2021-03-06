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
    interface ITeacherService
    {
        [OperationContract]
        CommonLib.ReturnState AddTeacherInfo(TeacherInfoView model);

        [OperationContract]
        TeacherInfoView GetTeacherInfo(string email);

        [OperationContract]
        CommonLib.ReturnState UpdateTeacherrInfo(TeacherInfoView model);

        [OperationContract]
        bool HasMember(string email);

        [OperationContract]
        List<TeacherInfoView> GetTeacherInfoList();

        [OperationContract]
        CommonLib.ReturnState RemoveTeacherInfo(string email);

        [OperationContract]
        CommonLib.ReturnState AddComment(TeacherCommentView model);

        [OperationContract]
        CommonLib.ReturnState RemoveComment(TeacherCommentView model);

        [OperationContract]
        List<TeacherCommentView> GetCommentByEmail(string email);

        [OperationContract]
        int GetValidFloor(string code);

        [OperationContract]
        void RemoveTeacherComment(int id);
    }

    [DataContract]
    public class TeacherInfoView
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public DateTime RegisteDate { get; set; }

        [DataMember]
        public string Tel { get; set; }

        [DataMember(IsRequired = true)]
        public int University { get; set; }

        [DataMember]
        public string Sex { get; set; }

        [DataMember(IsRequired = true)]
        public int JobTitle { get; set; }

        [DataMember]
        public string Desp { get; set; }
    }

    public class TeacherCommentView
    {
        [DataMember(IsRequired =true)]
        public int Id { get; set; }

        [DataMember]
        public string Teacher { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime PubDate { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember(IsRequired = true)]
        public int Floor { get; set; }

    }
}
