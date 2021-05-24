using AutoMapper;
using UserService.Core.Models;

namespace UserService.Application.Commands.Authenticate
{
    class AuthenticateUserMapping : Profile
    {
        public AuthenticateUserMapping()
        {
            CreateMap<AuthenticateUserInputModel, User>()
                    .ForMember(dest =>
                        dest.Email,
                        opt => opt.MapFrom(src => src.email.ToString()))
                    .ForMember(dest =>
                        dest.Password,
                        opt => opt.MapFrom(src => src.password));
        }
    }
}
