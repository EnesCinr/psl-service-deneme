using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos.Place
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
