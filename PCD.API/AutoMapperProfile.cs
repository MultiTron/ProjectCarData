using AutoMapper;
using PCD.Data.Entities;
using PCD.Infrastructure.DTOs.Users;

namespace PCD.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserAlterModel, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dest => dest.DriversLicenseNumber, opt => opt.MapFrom(x => ""))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => ""))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(x => ""))
                .ForMember(dest => dest.Cars, opt => opt.MapFrom(x => new List<Car>()))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(x => DateTime.UtcNow));
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName));
        }
    }
}
