using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Utilities.Regex
{
    public static class RegexHelper
    {
        public static bool IsEmail(string email)
        {
            return new System.Text.RegularExpressions.Regex(
                @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$").IsMatch(email);
        }

        public static bool IsPasswordVerified(string password)
        {
            return new System.Text.RegularExpressions.Regex(
                @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}.$").IsMatch(password);
        }
    }
}
