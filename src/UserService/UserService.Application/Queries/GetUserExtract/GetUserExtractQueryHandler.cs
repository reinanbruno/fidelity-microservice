using AutoMapper;
using UserService.Core.Interfaces.Repositories;
using UserService.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Application.Queries.GetUserExtract
{
    public class GetUserExtractQueryHandler : IRequestHandler<GetUserExtractInputModel, List<GetUserExtractViewModel>>
    {
        private readonly IUserPointHistoryRepository _userPointHistoryRepository;
        private readonly IMapper _mapper;

        public GetUserExtractQueryHandler(IUserPointHistoryRepository userPointHistoryRepository, IMapper mapper)
        {
            _userPointHistoryRepository = userPointHistoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUserExtractViewModel>> Handle(GetUserExtractInputModel request, CancellationToken cancellationToken)
        {
            List<UserPointHistory> userPointHistories = await _userPointHistoryRepository
                                                              .Filter(x => x.UserId == request.userId &&
                                                                           x.RegistrationDate.Date >= request.initial_date.Date &&
                                                                           x.RegistrationDate.Date <= request.final_date.Date);

            return _mapper.Map<List<GetUserExtractViewModel>>(userPointHistories);
        }
    }
}
