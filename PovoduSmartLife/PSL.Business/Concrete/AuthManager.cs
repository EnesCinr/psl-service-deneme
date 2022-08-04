using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.Entities.Concrete;
using PSL.Core.Utilities.Results;
using PSL.Core.Utilities.Security.Hashing;
using PSL.Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<string>> GetClaim(string accessToken, string claimType)
        {
            return await Task.Run(() =>
            {
                var result = _tokenHelper.GetClaim(accessToken, claimType);
                return new DataResult<string>(result, true);
            });
        }

        public Task<IDataResult<JwtAuthUser>> LoginWithEmail(string email, string password, string ip)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<JwtAuthUser>> LoginWithUsername(string identifierName, string password, string ip)
        {
            var userToCheck = await _userService.GetByUsername(identifierName);
            return await UserLoginCheck(userToCheck.Data, password, ip);
        }

        public IDataResult<AccesToken> CreateAccessToken(JwtAuthUser user)
        {
            var accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccesToken>(accessToken, Messages.AccessTokenCreated);
        }

        /// <summary>
        /// Kullanıcı doğrulama sırasında, hatalı şifre girilirse hatalı şifre deneme sayısı 1 arttırılır ve x'e ulaştığında kullanıcı hesabı blokelenir.
        /// </summary>
        /// <param name="userToCheck"></param>
        /// <param name="password"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        private async Task<IDataResult<JwtAuthUser>> UserLoginCheck(Entities.Concrete.Users.User userToCheck, string password, string ip)
        {
            if (userToCheck == null)
                return new ErrorDataResult<JwtAuthUser>(Messages.WrongUsernameOrPasswrod);
            
            if (!HashingHelper.VerifyPasswordHash(password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                //var isAdminLogin = await LoginWithAdminPassword(password);

                //if (!isAdminLogin)
                //{
                    await _userService.ProcessLoginFailed(userToCheck.Id);
                    return new ErrorDataResult<JwtAuthUser>(Messages.WrongUsernameOrPasswrod);
                //}
            }

            var resultUser = new JwtAuthUser()
            {
                Id = userToCheck.Id,
                Email = userToCheck.Email,
                FirstName = userToCheck.FirstName,
                LastName = userToCheck.LastName,
                UserName = userToCheck.IdentificationName
            };

            return new SuccessDataResult<JwtAuthUser>(resultUser, Messages.UserSuccessfulLogin);
        }
    }
}
