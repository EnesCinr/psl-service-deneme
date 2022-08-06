using PSL.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete.Devices
{
    public class DeviceTypeClassificationRelation : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public int DeviceTypeId { get; set; }
        public int DeviceTypeClassification { get; set; }
    }
}
