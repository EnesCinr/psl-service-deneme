using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Utilities.HttpContext.Abstract
{
    public interface IHttpContextAccessorUtilities
    {
        /// <summary>
        /// HttpContext.Request.Headers' dan Origin değerini döner.
        /// Portal API' yi kullanan/çağıran uygulamanın URL' dir.
        /// </summary>
        /// <returns></returns>
        string GetAppUrlThatCallsTheApi();

        /// <summary>
        /// Portal API' nin URL' ni verir.
        /// </summary>
        /// <returns></returns>
        string GetCurrentApiUrl();
    }
}
