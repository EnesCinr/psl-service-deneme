using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos.Device
{
    public class DeviceDto
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int DeviceTypeId { get; set; }
        public string Icon { get; set; }
        public string SerialNumber { get; set; }
        public string HomeKitPairNumber { get; set; }
        public string HomeKitSetupId { get; set; }
        public string MacAddress { get; set; }
        public bool IsHomeKitDevice { get; set; } = false;
        public string DeviceJsonValue { get; set; }
        public int? RoomId { get; set; } = 0;

        //public string Name { get; set; }
        //public string DeviceNumber { get; set; }
        //public int? RoomId { get; set; }
        //public int DeviceTypeId { get; set; }
        //public string Icon { get; set; }
        //public string SerialNumber { get; set; }
        //public string MacAddress { get; set; }
        //public bool IsHomeKitDevice { get; set; }
        //public string HomeKitPairNumber { get; set; }
        //public string HomeKitSetupId { get; set; }
        //public string DeviceJsonValue { get; set; }
        //public bool IsActive { get; set; } = true;
        //public bool InUse { get; set; }
    }
}
