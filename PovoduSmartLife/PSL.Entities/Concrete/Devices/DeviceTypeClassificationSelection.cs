using PSL.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete.Devices
{
    public class DeviceTypeClassificationSelection : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int DeviceTypeId { get; set; }
        public int? DeviceTypeClassificationId { get; set; }
        //public virtual Device Device { get; set; }
    }
}
