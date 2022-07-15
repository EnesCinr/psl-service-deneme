using Microsoft.Extensions.DependencyInjection;
using PSL.Business.Concrete;
using PSL.Business.Interfaces;
using PSL.Core.Utilities.Security.Jwt;
using PSL.DataAccess.Concrete.EntityFramework.Dal.Devices;
using PSL.DataAccess.Concrete.EntityFramework.Dal.Users;
using PSL.DataAccess.Interfaces.Devices;
using PSL.DataAccess.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.DependencyResolvers.NetCore
{
    public class NetCoreBusinessModule
    {
        public static void Common(IServiceCollection services)
        {

            #region Token
            services.AddScoped<ITokenHelper, JwtHelper>();
            #endregion

            #region Dals
            services.AddScoped<IDeviceDal, EFDeviceDal>();
            services.AddScoped<IUserDal, EFUserDal>();
            services.AddScoped<IUserLocationDal, EFUserLocationDal>();
            services.AddScoped<IUserRoomDal, EFUserRoomDal>();
            services.AddScoped<IUserDeviceDal, EFUserDeviceDal>();
            services.AddScoped<IUserRelationDal, EFUserRelationDal>();
            #endregion

            #region Services
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserService, UserManager>();
            #endregion


        }
    }
}
