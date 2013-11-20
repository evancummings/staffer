using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staffer.Utilities
{
    public static class JsonSanitizer
    {
        public static string Santize(string str)
        {
            str = str.Replace("+biography", "biography");
            return str;
        }
    }
}
