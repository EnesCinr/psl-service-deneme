using AutoMapper;
using PSL.Entities.Dtos.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos._Profiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<DeviceDto, Concrete.Devices.Device>().ReverseMap();
        }
    }
}
