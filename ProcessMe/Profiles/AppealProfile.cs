using AutoMapper;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Profiles
{
    public class AppealProfile : Profile
    {
        public AppealProfile()
        {
            CreateMap<AppealForCreationDto, Appeal>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                dest => dest.ClientName,
                opt => opt.MapFrom(src => src.ClientName))
                .ForMember(
                dest => dest.ClientPhone,
                opt => opt.MapFrom(src => src.ClientPhone))
                .ForMember(
                dest => dest.ClientEmail,
                opt => opt.MapFrom(src => src.ClientEmail))
                .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
                .ForMember(
                dest => dest.CommunicationWay,
                opt => opt.MapFrom(src => src.CommunicationWay))
                .ForMember(
                dest => dest.RecieveDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
