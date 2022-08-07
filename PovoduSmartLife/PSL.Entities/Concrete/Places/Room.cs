using PSL.Core.Entities;
using PSL.Entities.Concrete.Devices;
using PSL.Entities.Concrete.Users;

namespace PSL.Entities.Concrete.Places
{
    public class Room : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceId { get; set; }
        public string Icon { get; set; }
        public string BackgroundImage { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Place Place { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}
