using AutoMapper;
using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Queries.GetOrderTracking
{
    public class GetOrderTrackingQueryHandler : IRequestHandler<GetOrderTrackingInputModel, List<GetOrderTrackingViewModel>>
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly IMapper _mapper;

        public GetOrderTrackingQueryHandler(IOrderHistoryRepository orderHistoryRepository, IMapper mapper)
        {
            _orderHistoryRepository = orderHistoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderTrackingViewModel>> Handle(GetOrderTrackingInputModel request, CancellationToken cancellationToken)
        {
            List<OrderHistory> orderHistories = await _orderHistoryRepository.GetList(request.orderId);
            return _mapper.Map<List<GetOrderTrackingViewModel>>(orderHistories);
        }
    }
}
