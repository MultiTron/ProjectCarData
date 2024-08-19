using AutoMapper;
using PCD.Data.Entities;
using PCD.Infrastructure.DTOs.Cars;
using PCD.Infrastructure.DTOs.Users;

namespace PCD.API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserAlterModel, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
            .ForMember(dest => dest.DriversLicenseNumber, opt => opt.MapFrom(x => x.DriversLicenseNumber))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(x => x.Password))
            .ForMember(dest => dest.Cars, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore());
        CreateMap<User, UserViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
            .ForMember(dest => dest.DriversLicenseNumber, opt => opt.MapFrom(x => x.DriversLicenseNumber))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(x => x.Password));
        CreateMap<CarAlterModel, Car>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Model, opt => opt.MapFrom(x => x.Model))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(x => x.Brand))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(x => x.Year))
            .ForMember(dest => dest.LicensePlateNumber, opt => opt.MapFrom(x => x.LicensePlateNumber))
            .ForMember(dest => dest.CountryOfRegistration, opt => opt.MapFrom(x => x.CountryOfRegistration))
            .ForMember(dest => dest.VIN, opt => opt.MapFrom(x => x.VIN))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.UserId))
            .ForMember(dest => dest.Trips, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore());
        CreateMap<Car, CarViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(x => x.Model))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(x => x.Brand))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(x => x.Year))
            .ForMember(dest => dest.LicensePlateNumber, opt => opt.MapFrom(x => x.LicensePlateNumber))
            .ForMember(dest => dest.CountryOfRegistration, opt => opt.MapFrom(x => x.CountryOfRegistration))
            .ForMember(dest => dest.VIN, opt => opt.MapFrom(x => x.VIN))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.UserId));
    }
}
