using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos.Place
{
    public class PlaceWithRoomsForDefaultValueDto
    {
        public PlaceDto Place { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
