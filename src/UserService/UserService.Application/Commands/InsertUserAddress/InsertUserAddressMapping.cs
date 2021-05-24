using AutoMapper;
using UserService.Core.Models;
using System;

namespace UserService.Application.Commands.InsertUserAddress
{
    public class InsertUserAddressMapping : Profile
    {
        public InsertUserAddressMapping()
        {
            CreateMap<InsertUserAddressInputModel, UserAddress>()
                   .ForMember(dest =>
                       dest.UserId,
                       opt => opt.MapFrom(src => src.userId))
                   .ForMember(dest =>
                       dest.Number,
                       opt => opt.MapFrom(src => src.number))
                   .ForMember(dest =>
                       dest.Address,
                       opt => opt.MapFrom(src => src.address))
                   .ForMember(dest =>
                       dest.ZipCode,
                       opt => opt.MapFrom(src => src.zip_code.ToString()))
                   .ForMember(dest =>
                       dest.State,
                       opt => opt.MapFrom(src => src.state.ToString()))
                   .ForMember(dest =>
                       dest.City,
                       opt => opt.MapFrom(src => src.city.ToString()))
                   .ForMember(dest =>
                       dest.District,
                       opt => opt.MapFrom(src => src.district))
                   .ForMember(dest =>
                       dest.InformationAdditional,
                       opt => opt.MapFrom(src => src.information_additional))
                   .ForMember(dest =>
                       dest.RegistrationDate,
                       opt => opt.MapFrom(src => DateTime.Now))
                   .ForMember(dest =>
                       dest.Active,
                       opt => opt.MapFrom(src => true));
        }
    }
}
