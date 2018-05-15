using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Svcs
{
    public class UtilityServiceFactory
    {
        private static UtilityService.UtilityService utilityClient = new UtilityService.UtilityService();
        private static bool specify = true;

        public int IndexOfUniversity(string university)
        {
            int result;
            utilityClient.IndexOfUniversity(university, out result, out specify);
            return result;
        }

        public string NameOfUniversity(int id)
        {
            return utilityClient.NameOfUniversity(id, specify);
        }

        public int IndexOfJobTitle(string name)
        {
            int result;
            utilityClient.IndexOfJobTitle(name, out result, out specify);
            return result;
        }

        public string NameOfJobTitle(int id)
        {
            return utilityClient.NameOfJobTitle(id, specify);
        }

        public bool AddTeacherCourseMap(string email, string code)
        {
            bool result;
            utilityClient.AddTeacherCourseMap(email, code, out result, out specify);
            return result;
        }

        public bool DelTeacherCourseMap(string email, string code)
        {
            bool result;
            utilityClient.DelTeacherCourseMap(email, code, out result, out specify);
            return result;
        }

        public List<string> GetCourseIdByTeacher(string email)
        {
            var tmp =  utilityClient.GetCourseIdByTeacher(email);
            var result = new List<string>();
            foreach(var item in tmp)
            {
                result.Add(item);
            }
            return result;
        }

        public List<string> GetTeacherByCourseId(string code)
        {
            var tmp = utilityClient.GetTeacherByCourseId(code);
            var result = new List<string>();
            foreach (var item in tmp)
            {
                result.Add(item);
            }
            return result;
        }

        public string NameOfCourse(string code)
        {
            return utilityClient.NameOfCourse(code);
        }

        public List<string> GetUniversityList()
        {
            var tmp = utilityClient.GetUniversityList();
            var result = new List<string>();
            foreach (var item in tmp)
            {
                result.Add(item);
            }
            return result;
        }

        public string[] GetFilterLisst()
        {
            return utilityClient.GetFilterLisst();
        }


        public bool AddFilterString(string content)
        {
            bool result;
            utilityClient.AddFilterString(content, out result, out specify);
            return result;
        }

        public bool RemoveFilterString(string content)
        {
            bool result;
            utilityClient.RemoveFilterString(content, out result, out specify);
            return result;
        }
    }
}