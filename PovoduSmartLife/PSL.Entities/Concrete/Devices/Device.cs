using PSL.Core.Entities;
using PSL.Entities.Concrete.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete.Devices
{
    public class Device: BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeviceNumber { get; set; }
        public int RoomId { get; set; }
        public string DeviceType { get; set; }
        public string SubType { get; set; }
        public string Icon { get; set; }
        public string SerialNumber { get; set; }
        public string MacAddress { get; set; }
        public bool IsHomeKitDevice { get; set; }
        public string HomeKitPairNumber { get; set; }
        public string HomeKitSetupId { get; set; }
        public string DeviceJsonValue { get; set; }
        public bool IsActive { get; set; } = true;
        public bool InUse { get; set; }

        public virtual Room Room { get; set; }
    }
}
