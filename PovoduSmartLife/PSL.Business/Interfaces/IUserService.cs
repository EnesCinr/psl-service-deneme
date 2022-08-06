using PSL.Core.Utilities.Results;
using PSL.Entities.Concrete.Users;
using PSL.Entities.Dtos.User;
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
        Task<IDataResult<int>> Add(UserCreateDto user, int createdByUserId);
        Task<bool> ApproveUser(string approveCode, int userId);
    }
}
