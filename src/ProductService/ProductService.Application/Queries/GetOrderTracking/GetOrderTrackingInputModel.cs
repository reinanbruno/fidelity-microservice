using MediatR;
using System.Collections.Generic;

namespace ProductService.Application.Queries.GetOrderTracking
{
    public class GetOrderTrackingInputModel : IRequest<List<GetOrderTrackingViewModel>>
    {
        public int orderId { get; set; }
    }
}
