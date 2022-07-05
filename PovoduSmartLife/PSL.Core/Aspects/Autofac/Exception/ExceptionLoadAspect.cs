using Castle.DynamicProxy;
using PSL.Core.CrossCuttingConcerns.Logging;
using PSL.Core.CrossCuttingConcerns.Logging.Log4Net;
using PSL.Core.Utilities.Interceptors;
using PSL.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Aspects.Autofac.Exception
{
    public class ExceptionLoadAspect : MethodInterception
    {
        private LoggerServiceBase _loggerService;
        public ExceptionLoadAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new System.Exception(AspectMessages.WrongLoggerType);

            _loggerService = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerService.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter()
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name,
                });
            }

            var logDetail = new LogDetailWithException()
            {
                LogParameters = logParameters,
                MethodName = invocation.Method.Name,
                EventDate = DateTime.Now
            };

            return logDetail;
        }
    }
}
