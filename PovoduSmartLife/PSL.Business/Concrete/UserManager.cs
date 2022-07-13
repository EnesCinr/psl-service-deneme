using AutoMapper;
using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.Utilities.Business;
using PSL.Core.Utilities.Results;
using PSL.Core.Utilities.Security.Hashing;
using PSL.Core.Utilities.Toolkit;
using PSL.DataAccess.Interfaces.Users;
using PSL.Entities.Concrete.Users;
using PSL.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
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

        public async Task<IDataResult<int>> Add(UserCreateDto user, int createdByUserId)
        {
            var passwordValidateResult = BusinessRules.Run(CheckIfPasswordNotValidated(user.Password));
            if (passwordValidateResult != null)
                return new ErrorDataResult<int>(passwordValidateResult.Message);

            var passwordRegexVerifiedResult = BusinessRules.Run(CheckIfPasswordNotValidated(user.Password));
            if (passwordRegexVerifiedResult != null)
                return new ErrorDataResult<int>(Messages.UserPasswordRulesError);

            var userEntity = new User();
            //_mapper.Map(user, userEntity);

            IResult result = BusinessRules.Run(await CheckIfUserUsernameAlreadyExists(user.UserName));
            if (result != null)
                throw new DuplicateNameException(result.Message);

            userEntity.IdentificationName = user.UserName;
            userEntity.IsActive = true;
            HashingHelper.CreatePasswordHash(user.Password, out var passwordHash, out var passwordSalt);
            userEntity.PasswordSalt = passwordSalt;
            userEntity.PasswordHash = passwordHash;
            userEntity.IsDelete = false;
            userEntity.CreatedUser = createdByUserId;
            userEntity.CreatedDate = DateTime.Now;

            await _userDal.Add(userEntity);

            return new SuccessDataResult<int>(userEntity.Id);
        }

        private async Task<IResult> CheckIfUserUsernameAlreadyExists(string username)
        {
            var user = await _userDal.ExistAsync(p => p.IdentificationName.Trim() == username.Trim());

            if (user)
                return new ErrorResult(Messages.UserNameAlreadyExist);

            return new SuccessResult();
        }
        private IResult CheckIfPasswordNotValidated(string password)
        {
            var result = PasswordHelper.CheckPasswordVerified(password);
            if (!result.Success)
                return new ErrorResult(Messages.UserPasswordRulesError);

            return new SuccessResult();
        }
    }
}
