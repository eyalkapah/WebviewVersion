using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewVersion
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return String.IsNullOrEmpty(s);
        }
    }
}
