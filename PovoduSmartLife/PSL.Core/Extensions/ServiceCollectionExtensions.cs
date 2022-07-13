using Microsoft.Extensions.DependencyInjection;
using PSL.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region Static Methods
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
        #endregion
    }
}
