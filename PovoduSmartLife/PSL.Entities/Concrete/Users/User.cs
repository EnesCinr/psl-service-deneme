using PSL.Core.Entities;
using PSL.Entities.Concrete.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete.Users
{
    public class User : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string IdentificationName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
