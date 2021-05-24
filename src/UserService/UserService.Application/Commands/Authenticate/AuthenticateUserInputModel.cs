using UserService.Application.Commands.Contract;
using UserService.Core.ValueObjects;
using MediatR;

namespace UserService.Application.Commands.Authenticate
{
    public class AuthenticateUserInputModel : IRequest<ICommandResult<string>>
    {
        public Email email { get; set; }
        public string password { get; set; }
    }
}
