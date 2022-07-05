using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccesToken CreateToken(JwtAuthUser user);
        bool ValidateToken(string accessToken);
        string GetClaim(string accessToken, string claimType);
    }
}
