using AutoMapper;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleForCreationDto, Role>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type));
        }
    }
}
