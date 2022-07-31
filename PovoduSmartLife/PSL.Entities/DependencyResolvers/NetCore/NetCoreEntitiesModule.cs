using AutoMapper.EquivalencyExpression;
using Microsoft.Extensions.DependencyInjection;

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
