using AutoMapper;
using PSL.Entities.Dtos.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos._Profiles
{
    public class RoomProfile: Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomDto, Concrete.Places.Room>().ReverseMap();

            CreateMap<Concrete.Places.Room, Concrete.Places.Room>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedUser, opt => opt.Ignore());
        }
    }
}
