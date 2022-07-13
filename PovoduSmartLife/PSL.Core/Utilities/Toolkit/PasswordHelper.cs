using PSL.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Utilities.Toolkit
{
    public static class PasswordHelper
    {
        public static IResult CheckPasswordVerified(string password)
        {
            if (password.Length < 8)
                return new ErrorResult();

            if (!password.Any(char.IsUpper))
                return new ErrorResult();

            if (!password.Any(char.IsLower))
                return new ErrorResult();

            if (!password.Any(char.IsNumber))
                return new ErrorResult();

            return new SuccessResult();
        }
    }
}
