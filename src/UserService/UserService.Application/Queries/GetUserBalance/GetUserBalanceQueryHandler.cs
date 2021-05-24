using UserService.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Application.Queries.GetUserBalance
{
    public class GetUserBalanceQueryHandler : IRequestHandler<GetUserBalanceInputModel, decimal>
    {
        private readonly IUserRepository _userRepository;

        public GetUserBalanceQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<decimal> Handle(GetUserBalanceInputModel request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetPointsBalance(request.userId);
        }
    }
}
