using PSL.Core.Entities;

namespace PSL.Entities.Concrete.Places
{
    public class Place : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
