using AutoMapper;
using UserService.Core.Models;

namespace UserService.Application.Queries.GetUserExtract
{
    class GetUserExtractViewModelMapping : Profile
    {
        public GetUserExtractViewModelMapping()
        {
            CreateMap<UserPointHistory, GetUserExtractViewModel>()
                   .ForMember(dest =>
                       dest.pointsBalance,
                       opt => opt.MapFrom(src => src.PointBalance))
                   .ForMember(dest =>
                       dest.registrationDate,
                       opt => opt.MapFrom(src => src.RegistrationDate.ToString("dd/MM/yyyy HH:mm:ss")));
        }
    }
}
