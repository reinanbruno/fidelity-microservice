using AutoMapper;
using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Queries.GetOrders
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderInputModel, List<GetOrderViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderViewModel>> Handle(GetOrderInputModel request, CancellationToken cancellationToken)
        {
            List<Order> orders = await _orderRepository.Filter(x => x.UserId == request.userId);
            return _mapper.Map<List<GetOrderViewModel>>(orders);
        }
    }
}
