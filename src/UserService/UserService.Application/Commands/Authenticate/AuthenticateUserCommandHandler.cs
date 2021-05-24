using UserService.Application.Commands.Contract;
using UserService.Core.Interfaces.Repositories;
using UserService.Core.Interfaces.Services;
using UserService.Core.Models;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Application.Commands.Authenticate
{
    class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserInputModel, ICommandResult<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly ICryptographyService _cryptographyService;

        public AuthenticateUserCommandHandler(IUserRepository userRepository, IAuthService authService, ICryptographyService cryptographyService)
        {
            _userRepository = userRepository;
            _authService = authService;
            _cryptographyService = cryptographyService;
        }

        public async Task<ICommandResult<string>> Handle(AuthenticateUserInputModel request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.Find(x => x.Email == request.email.ToString() &&
                                                        x.Password == _cryptographyService.Encrypt(request.password) &&
                                                        x.Active == 1);

            if (user == null)
            {
                return new CommandResult<string>
                {
                    message = "Ops! E-mail ou usuário inválido.",
                    success = false,
                    httpStatusCode = HttpStatusCode.NotFound
                };
            }

            return new CommandResult<string>
            {
                response = _authService.GenerateToken(user),
                message = "Usuário autenticado com sucesso!",
                success = true,
                httpStatusCode = HttpStatusCode.OK
            };
        }
    }
}

