using AutoMapper.EquivalencyExpression;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.DependencyResolvers.NetCore
{
    public class NetCoreEntitiesModule
    {
        public static void Common(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NetCoreEntitiesModule));
            services.AddAutoMapper(cfg =>
            {
                cfg.AddCollectionMappers();
            });
        }
    }
}
