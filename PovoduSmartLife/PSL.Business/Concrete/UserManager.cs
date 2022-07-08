using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.Utilities.Results;
using PSL.DataAccess.Interfaces.Users;
using PSL.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<User>> GetById(int userId)
        {
            return new SuccessDataResult<User>(await _userDal.SingleOrDefault(u => u.Id == userId, u => u.UserRelations));
        }

        public async Task<IDataResult<User>> GetByUsername(string identificationName)
        {
            return new SuccessDataResult<User>(await _userDal.SingleOrDefault(u => u.IdentificationName == identificationName, u => u.UserRelations));
        }

        /// <summary>
        /// kullanıcı başarısız giriş denemeleri 3'e ulaştığında blokelenir
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IResult> ProcessLoginFailed(int userId)
        {
            var user = await _userDal.GetByIdAsync(userId);
            await _userDal.Update(user);
            return new SuccessResult(Messages.Success_Updated);
        }
    }
}
