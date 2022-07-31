using AutoMapper;
using PSL.Entities.Dtos.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos._Profiles
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<PlaceDto, Concrete.Places.Place>().ReverseMap();
        }
    }
}
