using Microsoft.Extensions.Primitives;
using PSL.Core.Entities.Concrete;
using PSL.Core.Utilities.Results;
using PSL.Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Interfaces
{
    public interface IAuthService
    {
        Task<IDataResult<JwtAuthUser>> LoginWithEmail(string email, string password, string ip);
        Task<IDataResult<JwtAuthUser>> LoginWithUsername(string email, string password, string ip);
        Task<IDataResult<string>> GetClaim(string accessToken, string claimType);
        IDataResult<AccesToken> CreateAccessToken(JwtAuthUser user);
    }
}
