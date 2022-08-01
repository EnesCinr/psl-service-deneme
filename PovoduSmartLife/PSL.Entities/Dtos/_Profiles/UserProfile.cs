using AutoMapper;
using PSL.Entities.Dtos.Place;
using PSL.Entities.Dtos.User;

namespace PSL.Entities.Dtos._Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, Concrete.Users.User>()
                .ForPath(dst => dst.IdentificationName, opt => opt.MapFrom(src => src.Email))
                .ForPath(dst => dst.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<Concrete.Users.User, Core.Entities.Concrete.JwtAuthUser>();
        }
    }
}
