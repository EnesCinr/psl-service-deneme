using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PSL.Core.CrossCuttingConcerns.Caching;
using PSL.Core.CrossCuttingConcerns.Caching.Microsoft;
using PSL.Core.Utilities.HttpContext;
using PSL.Core.Utilities.HttpContext.Abstract;
using PSL.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        #region Methods
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IHttpContextAccessorUtilities, HttpContextAccessorUtilities>();
            services.AddSingleton<Stopwatch>();
        }
        #endregion
    }
}
