using PSL.Core.Utilities.Results;
using PSL.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Interfaces
{
    public interface IUserService
    {
        Task<IDataResult<User>> GetById(int userId);        
        Task<IDataResult<User>> GetByUsername(string İdentificationName);
        Task<IResult> ProcessLoginFailed(int userId);
    }
}
