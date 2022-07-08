using PSL.Core.Entities;
using PSL.Entities.Concrete.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete.Users
{
    public class UserDevice: BaseEntity, IEntity
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int DeviceTypeId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        public virtual Device Device { get; set; }
    }
}
