using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CommonLib
{
    public static class Utilities
    {
        public static string Filter(string content, List<string> filters)
        {
            var result = content;
            foreach (var filter in filters)
            {
                result = Regex.Replace(result, filter, "");
            }

            return result;
        }

        public static string MakeCourseCode(string code)
        {
            var prefix = Regex.Replace(code, "[0-9]*", "");
            var suffix = System.Convert.ToInt32(Regex.Replace(code, "[a-zA-Z_]*", ""));
            return string.Format("{0}{1:0000}", prefix, suffix + 1);
        }
    }
}
