using PSL.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete.Users
{
    public class UserRelation : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? UserLocationId { get; set; } = null;
        public int? UserRoomId { get; set; } = null;
        public int? UserDeviceId { get; set; } = null;

        public virtual User User { get; set; } 
        public virtual UserLocation? UserLocation { get; set;}
        public virtual UserRoom? UserRoom { get; set;}
        public virtual UserDevice? UserDevice { get; set; }

    }
}
