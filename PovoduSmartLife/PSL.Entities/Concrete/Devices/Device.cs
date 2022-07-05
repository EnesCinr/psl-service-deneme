using PSL.Core.Entities;
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
        public string MacAddress { get; set; }
        public bool IsActive { get; set; } = true;
        public bool InUse { get; set; }
    }
}
