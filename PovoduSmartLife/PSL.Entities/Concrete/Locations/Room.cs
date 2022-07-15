using PSL.Core.Entities;
using PSL.Entities.Concrete.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete.Locations
{
    public class Room : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public string Icon { get; set; }
        public string BackgroundImage { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}
