using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string UserName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
        public DateTime EventDate { get; set; }
        public string IpAdress { get; set; }
        public override string ToString()
        {
            return $"{ServiceName}.{MethodName}";
        }
    }
}
