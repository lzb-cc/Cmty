﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin.UtilityService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UtilityService.IUtilityService")]
    public interface IUtilityService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/IndexOfUniversity", ReplyAction="http://tempuri.org/IUtilityService/IndexOfUniversityResponse")]
        int IndexOfUniversity(string university);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/IndexOfUniversity", ReplyAction="http://tempuri.org/IUtilityService/IndexOfUniversityResponse")]
        System.Threading.Tasks.Task<int> IndexOfUniversityAsync(string university);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/NameOfUniversity", ReplyAction="http://tempuri.org/IUtilityService/NameOfUniversityResponse")]
        string NameOfUniversity(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/NameOfUniversity", ReplyAction="http://tempuri.org/IUtilityService/NameOfUniversityResponse")]
        System.Threading.Tasks.Task<string> NameOfUniversityAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/IndexOfJobTitle", ReplyAction="http://tempuri.org/IUtilityService/IndexOfJobTitleResponse")]
        int IndexOfJobTitle(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/IndexOfJobTitle", ReplyAction="http://tempuri.org/IUtilityService/IndexOfJobTitleResponse")]
        System.Threading.Tasks.Task<int> IndexOfJobTitleAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/NameOfJobTitle", ReplyAction="http://tempuri.org/IUtilityService/NameOfJobTitleResponse")]
        string NameOfJobTitle(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/NameOfJobTitle", ReplyAction="http://tempuri.org/IUtilityService/NameOfJobTitleResponse")]
        System.Threading.Tasks.Task<string> NameOfJobTitleAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/AddTeacherCourseMap", ReplyAction="http://tempuri.org/IUtilityService/AddTeacherCourseMapResponse")]
        bool AddTeacherCourseMap(string email, string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/AddTeacherCourseMap", ReplyAction="http://tempuri.org/IUtilityService/AddTeacherCourseMapResponse")]
        System.Threading.Tasks.Task<bool> AddTeacherCourseMapAsync(string email, string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/DelTeacherCourseMap", ReplyAction="http://tempuri.org/IUtilityService/DelTeacherCourseMapResponse")]
        bool DelTeacherCourseMap(string email, string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/DelTeacherCourseMap", ReplyAction="http://tempuri.org/IUtilityService/DelTeacherCourseMapResponse")]
        System.Threading.Tasks.Task<bool> DelTeacherCourseMapAsync(string email, string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/GetCourseIdByTeacher", ReplyAction="http://tempuri.org/IUtilityService/GetCourseIdByTeacherResponse")]
        string[] GetCourseIdByTeacher(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/GetCourseIdByTeacher", ReplyAction="http://tempuri.org/IUtilityService/GetCourseIdByTeacherResponse")]
        System.Threading.Tasks.Task<string[]> GetCourseIdByTeacherAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/GetTeacherByCourseId", ReplyAction="http://tempuri.org/IUtilityService/GetTeacherByCourseIdResponse")]
        string[] GetTeacherByCourseId(string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/GetTeacherByCourseId", ReplyAction="http://tempuri.org/IUtilityService/GetTeacherByCourseIdResponse")]
        System.Threading.Tasks.Task<string[]> GetTeacherByCourseIdAsync(string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/NameOfCourse", ReplyAction="http://tempuri.org/IUtilityService/NameOfCourseResponse")]
        string NameOfCourse(string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/NameOfCourse", ReplyAction="http://tempuri.org/IUtilityService/NameOfCourseResponse")]
        System.Threading.Tasks.Task<string> NameOfCourseAsync(string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/GetUniversityList", ReplyAction="http://tempuri.org/IUtilityService/GetUniversityListResponse")]
        string[] GetUniversityList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/GetUniversityList", ReplyAction="http://tempuri.org/IUtilityService/GetUniversityListResponse")]
        System.Threading.Tasks.Task<string[]> GetUniversityListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/GetFilterLisst", ReplyAction="http://tempuri.org/IUtilityService/GetFilterLisstResponse")]
        string[] GetFilterLisst();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/GetFilterLisst", ReplyAction="http://tempuri.org/IUtilityService/GetFilterLisstResponse")]
        System.Threading.Tasks.Task<string[]> GetFilterLisstAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/AddFilterString", ReplyAction="http://tempuri.org/IUtilityService/AddFilterStringResponse")]
        bool AddFilterString(string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/AddFilterString", ReplyAction="http://tempuri.org/IUtilityService/AddFilterStringResponse")]
        System.Threading.Tasks.Task<bool> AddFilterStringAsync(string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/RemoveFilterString", ReplyAction="http://tempuri.org/IUtilityService/RemoveFilterStringResponse")]
        bool RemoveFilterString(string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtilityService/RemoveFilterString", ReplyAction="http://tempuri.org/IUtilityService/RemoveFilterStringResponse")]
        System.Threading.Tasks.Task<bool> RemoveFilterStringAsync(string content);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUtilityServiceChannel : Admin.UtilityService.IUtilityService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UtilityServiceClient : System.ServiceModel.ClientBase<Admin.UtilityService.IUtilityService>, Admin.UtilityService.IUtilityService {
        
        public UtilityServiceClient() {
        }
        
        public UtilityServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UtilityServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UtilityServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UtilityServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int IndexOfUniversity(string university) {
            return base.Channel.IndexOfUniversity(university);
        }
        
        public System.Threading.Tasks.Task<int> IndexOfUniversityAsync(string university) {
            return base.Channel.IndexOfUniversityAsync(university);
        }
        
        public string NameOfUniversity(int id) {
            return base.Channel.NameOfUniversity(id);
        }
        
        public System.Threading.Tasks.Task<string> NameOfUniversityAsync(int id) {
            return base.Channel.NameOfUniversityAsync(id);
        }
        
        public int IndexOfJobTitle(string name) {
            return base.Channel.IndexOfJobTitle(name);
        }
        
        public System.Threading.Tasks.Task<int> IndexOfJobTitleAsync(string name) {
            return base.Channel.IndexOfJobTitleAsync(name);
        }
        
        public string NameOfJobTitle(int id) {
            return base.Channel.NameOfJobTitle(id);
        }
        
        public System.Threading.Tasks.Task<string> NameOfJobTitleAsync(int id) {
            return base.Channel.NameOfJobTitleAsync(id);
        }
        
        public bool AddTeacherCourseMap(string email, string code) {
            return base.Channel.AddTeacherCourseMap(email, code);
        }
        
        public System.Threading.Tasks.Task<bool> AddTeacherCourseMapAsync(string email, string code) {
            return base.Channel.AddTeacherCourseMapAsync(email, code);
        }
        
        public bool DelTeacherCourseMap(string email, string code) {
            return base.Channel.DelTeacherCourseMap(email, code);
        }
        
        public System.Threading.Tasks.Task<bool> DelTeacherCourseMapAsync(string email, string code) {
            return base.Channel.DelTeacherCourseMapAsync(email, code);
        }
        
        public string[] GetCourseIdByTeacher(string email) {
            return base.Channel.GetCourseIdByTeacher(email);
        }
        
        public System.Threading.Tasks.Task<string[]> GetCourseIdByTeacherAsync(string email) {
            return base.Channel.GetCourseIdByTeacherAsync(email);
        }
        
        public string[] GetTeacherByCourseId(string code) {
            return base.Channel.GetTeacherByCourseId(code);
        }
        
        public System.Threading.Tasks.Task<string[]> GetTeacherByCourseIdAsync(string code) {
            return base.Channel.GetTeacherByCourseIdAsync(code);
        }
        
        public string NameOfCourse(string code) {
            return base.Channel.NameOfCourse(code);
        }
        
        public System.Threading.Tasks.Task<string> NameOfCourseAsync(string code) {
            return base.Channel.NameOfCourseAsync(code);
        }
        
        public string[] GetUniversityList() {
            return base.Channel.GetUniversityList();
        }
        
        public System.Threading.Tasks.Task<string[]> GetUniversityListAsync() {
            return base.Channel.GetUniversityListAsync();
        }
        
        public string[] GetFilterLisst() {
            return base.Channel.GetFilterLisst();
        }
        
        public System.Threading.Tasks.Task<string[]> GetFilterLisstAsync() {
            return base.Channel.GetFilterLisstAsync();
        }
        
        public bool AddFilterString(string content) {
            return base.Channel.AddFilterString(content);
        }
        
        public System.Threading.Tasks.Task<bool> AddFilterStringAsync(string content) {
            return base.Channel.AddFilterStringAsync(content);
        }
        
        public bool RemoveFilterString(string content) {
            return base.Channel.RemoveFilterString(content);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveFilterStringAsync(string content) {
            return base.Channel.RemoveFilterStringAsync(content);
        }
    }
}
