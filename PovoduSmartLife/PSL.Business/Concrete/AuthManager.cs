using PSL.Business.Interfaces;
using PSL.Core.Entities.Concrete;
using PSL.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        public AuthManager()
        {
        }

        public Task<IDataResult<JwtAuthUser>> LoginWithEmail(string email, string password, string ip)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<JwtAuthUser>> LoginWithUsername(string email, string password, string ip)
        {
            throw new NotImplementedException();
        }
    }
}
