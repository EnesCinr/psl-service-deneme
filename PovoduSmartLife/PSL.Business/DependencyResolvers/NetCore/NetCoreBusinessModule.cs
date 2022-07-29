using Microsoft.Extensions.DependencyInjection;
using PSL.Business.Concrete;
using PSL.Business.Interfaces;
using PSL.Core.Utilities.Security.Jwt;
using PSL.DataAccess.Concrete.EntityFramework.Dal.Devices;
using PSL.DataAccess.Concrete.EntityFramework.Dal.Place;
using PSL.DataAccess.Concrete.EntityFramework.Dal.Room;
using PSL.DataAccess.Concrete.EntityFramework.Dal.Users;
using PSL.DataAccess.Interfaces.Devices;
using PSL.DataAccess.Interfaces.Places;
using PSL.DataAccess.Interfaces.Rooms;
using PSL.DataAccess.Interfaces.Users;

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
            services.AddScoped<IPlaceDal, EFPlaceDal>();
            services.AddScoped<IUserDal, EFUserDal>();
            services.AddScoped<IRoomDal, EFRoomDal>();
            #endregion

            #region Services
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IPlaceService, PlaceManager>();
            services.AddScoped<IRoomService, RoomManager>();
            #endregion
        }
    }
}
