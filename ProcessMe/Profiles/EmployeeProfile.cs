using AutoMapper;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeForCreationDto, Employee>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(
                dest => dest.DepartmentId,
                opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId));
        }
    }
}
