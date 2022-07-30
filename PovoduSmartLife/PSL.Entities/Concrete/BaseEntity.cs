using PSL.Core.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Concrete
{
    public class BaseEntity
    {
        [NeverUpdate]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        [NeverUpdate]
        public int CreatedUser { get; set; }
        public int? UpdatedUser { get; set; } = null;
    }
}
