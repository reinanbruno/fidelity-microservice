using UserService.Application.Commands.Contract;
using AutoMapper;
using UserService.Core.Interfaces;
using UserService.Core.Interfaces.Repositories;
using UserService.Core.Interfaces.Services;
using UserService.Core.Models;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace UserService.Application.Commands.InsertUser
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserInputModel, ICommandResult<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICryptographyService _cryptographyService;

        public InsertUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, ICryptographyService cryptographyService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cryptographyService = cryptographyService;
        }

        public async Task<ICommandResult<int>> Handle(InsertUserInputModel request, CancellationToken cancellationToken)
        {
            if (await _userRepository.Find(x => x.Email == request.email.ToString()) != null)
            {
                return new CommandResult<int>
                {
                    message = "Ops! Esse e-mail já existe.",
                    success = false,
                    httpStatusCode = HttpStatusCode.BadRequest
                };
            }

            if (await _userRepository.Find(x => x.IndividualTaxpayerRegistration == request.individualTaxpayerRegistration.ToString()) != null)
            {
                return new CommandResult<int>
                {
                    message = "Ops! Esse CPF já existe.",
                    success = false,
                    httpStatusCode = HttpStatusCode.BadRequest
                };
            }

            User user = _mapper.Map<InsertUserInputModel, User>(request);
            user.Password = _cryptographyService.Encrypt(user.Password);

            if(request.currentPointsValue > 0)
            {
                user.UserPointHistories.Add(new UserPointHistory
                {
                    PointBalance = request.currentPointsValue,
                    RegistrationDate = DateTime.Now
                });
            }

            await _userRepository.Insert(user);

            await _unitOfWork.Commit();

            return new CommandResult<int>
            {
                response = user.UserId,
                message = "Usuário criado com sucesso!",
                success = true,
                httpStatusCode = HttpStatusCode.Created
            };
        }
    }
}
