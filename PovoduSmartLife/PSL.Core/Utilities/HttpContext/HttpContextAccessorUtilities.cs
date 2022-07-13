using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PSL.Core.Utilities.HttpContext.Abstract;
using PSL.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Utilities.HttpContext
{
    public class HttpContextAccessorUtilities : IHttpContextAccessorUtilities
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HttpContextAccessorUtilities()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        /// <summary>
        /// HttpContext.Request.Headers' dan Origin değerini döner.
        /// API' yi kullanan/çağıran uygulamanın URL' dir.
        /// </summary>
        /// <returns></returns>
        public string GetAppUrlThatCallsTheApi()
        {
            var headers = _httpContextAccessor.HttpContext.Request.Headers;
            var link = string.Empty;
            if (headers.TryGetValue("Origin", out var originValue))
            {
                link = originValue;
            }

            return link;
        }

        /// <summary>
        /// API' nin URL' ni verir.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentApiUrl()
        {
            var current = _httpContextAccessor.HttpContext;

            return $"{current.Request.Scheme}://{current.Request.Host}{current.Request.PathBase}";

        }
    }
}
