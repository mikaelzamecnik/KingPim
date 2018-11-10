using AutoMapper;
using KingPim.Application.Account;
using KingPim.Domain.Entities;

namespace KingPim.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
