using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PSL.Core.DbContexts;
using PSL.Core.Utilities.Interceptors;
using PSL.Core.Utilities.IoC;

namespace PSL.Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            var httpContext = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            var _dbContext = httpContext.HttpContext.RequestServices.GetRequiredService<IDbContext>();

            _dbContext.Database.BeginTransaction();
            try
            {
                invocation.Proceed();

                _dbContext.Database.CommitTransaction();
            }
            catch (System.Exception e)
            {
                _dbContext.Database.RollbackTransaction();
                throw;
            }
        }
    }
}
