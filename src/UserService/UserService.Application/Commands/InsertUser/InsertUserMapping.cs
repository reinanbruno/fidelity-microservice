using AutoMapper;
using UserService.Core.Models;
using System;

namespace UserService.Application.Commands.InsertUser
{
    public class InsertUserMapping : Profile
    {
        public InsertUserMapping()
        {
            CreateMap<InsertUserInputModel, User>()
                    .ForMember(dest =>
                        dest.Email,
                        opt => opt.MapFrom(src => src.email.ToString()))
                    .ForMember(dest =>
                        dest.Cellphone,
                        opt => opt.MapFrom(src => src.cellphone.ToString()))
                    .ForMember(dest =>
                        dest.Name,
                        opt => opt.MapFrom(src => src.name.ToString()))
                    .ForMember(dest =>
                        dest.IndividualTaxpayerRegistration,
                        opt => opt.MapFrom(src => src.individualTaxpayerRegistration.ToString()))
                    .ForMember(dest =>
                        dest.BirthDate,
                        opt => opt.MapFrom(src => src.birthDate))
                    .ForMember(dest =>
                        dest.Password,
                        opt => opt.MapFrom(src => src.password))
                    .ForMember(dest =>
                        dest.RegistrationDate,
                        opt => opt.MapFrom(src => DateTime.Now))
                    .ForMember(dest =>
                        dest.Active,
                        opt => opt.MapFrom(src => 1))
                    .ForMember(dest =>
                        dest.CurrentPointsBalance,
                        opt => opt.MapFrom(src => src.currentPointsValue));
        }
    }
}
