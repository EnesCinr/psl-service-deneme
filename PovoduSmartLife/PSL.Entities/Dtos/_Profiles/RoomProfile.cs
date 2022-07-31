﻿using AutoMapper;
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
        }
    }
}
