using UserService.Application.Commands.Contract;
using AutoMapper;
using UserService.Core.Interfaces;
using UserService.Core.Interfaces.Repositories;
using UserService.Core.Models;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Application.Commands.InsertUserAddress
{
    public class InsertUserAddressCommandHandler : IRequestHandler<InsertUserAddressInputModel, ICommandResult<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsertUserAddressCommandHandler(IUserRepository userRepository, IUserAddressRepository userAddressRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult<int>> Handle(InsertUserAddressInputModel request, CancellationToken cancellationToken)
        {
            if(await _userRepository.Find(x => x.UserId == request.userId && x.Active == 1) == null)
            {
                return new CommandResult<int>
                {
                    message = "Usuário não encontrado!",
                    success = false,
                    httpStatusCode = HttpStatusCode.NotFound
                };

            }

            UserAddress userAddress = _mapper.Map<InsertUserAddressInputModel, UserAddress>(request);
            await _userAddressRepository.Insert(userAddress);
            await _unitOfWork.Commit();

            return new CommandResult<int>
            {
                response = userAddress.UserAddressId,
                message = "Endereço do usuário criado com sucesso!",
                success = true,
                httpStatusCode = HttpStatusCode.Created
            };
        }
    }
}
