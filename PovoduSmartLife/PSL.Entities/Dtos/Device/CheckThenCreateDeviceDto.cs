using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos.Device
{
    public class CheckThenCreateDeviceDto
    {
        public string deviceId { get; set; }
        public string macAddress { get; set; }
        public string deviceTypeCode { get; set; }
    }
}
