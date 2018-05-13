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
    }
}
