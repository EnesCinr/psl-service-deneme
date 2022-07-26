using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos.Location
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string BackgroundImage { get; set; }
        public int LocationId { get; set; }
    }
}
