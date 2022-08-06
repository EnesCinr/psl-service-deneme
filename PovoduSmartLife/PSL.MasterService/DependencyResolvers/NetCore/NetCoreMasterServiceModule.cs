using Microsoft.Extensions.DependencyInjection;
using PSL.MasterService.Business.Concrete;
using PSL.MasterService.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.MasterService.DependencyResolvers.NetCore
{
    public class NetCoreMasterServiceModule
    {
        public static void Common(IServiceCollection services)
        {
            #region Token

            #endregion

            #region Dals

            #endregion

            #region Services
            services.AddScoped<IMasterServiceService, MasterServiceManager>();
            #endregion
        }
    }
}
