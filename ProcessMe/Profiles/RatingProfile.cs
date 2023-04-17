using AutoMapper;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<RatingForCreationDto, Rating>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                dest => dest.Value,
                opt => opt.MapFrom(src => src.Value))
                .ForMember(
                dest => dest.Comment,
                opt => opt.MapFrom(src => src.Comment))
                .ForMember(
                dest => dest.EmployeeId,
                opt => opt.MapFrom(src => src.EmployeeId));
        }
    }
}
