using PSL.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete.Devices
{
    public class DeviceType : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string DeviceTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
