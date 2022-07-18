using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos.ExternalService.MasterService
{
    public class MasterDeviceDto
    {
        public string DeviceId { get; set; }
        public string SerialNumber { get; set; }
        public string MacAddress { get; set; }
        public string HomeKitPairNumber { get; set; }
        public string HomeKitSetupID { get; set; }
    }
}
