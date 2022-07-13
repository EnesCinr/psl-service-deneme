using AutoMapper;
using PSL.Entities.Dtos.User;

namespace PSL.Entities.Dtos._Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, Concrete.Users.User>()
                .ForPath(dst => dst.IdentificationName, opt => opt.MapFrom(src => src.UserName));
            CreateMap<Concrete.Users.User, Core.Entities.Concrete.JwtAuthUser>()
                .ForPath(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName));
        }
    }
}
