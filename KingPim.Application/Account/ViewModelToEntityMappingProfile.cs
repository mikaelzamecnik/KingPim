using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using KingPim.Domain.Entities.Identity;

namespace KingPim.Application.Account
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        // Mapping Viewmodel for use of Email as UserName
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
