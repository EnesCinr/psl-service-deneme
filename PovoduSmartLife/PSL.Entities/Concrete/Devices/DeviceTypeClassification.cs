using PSL.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete.Devices
{
    public class DeviceTypeClassification : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}
