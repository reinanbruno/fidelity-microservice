using MediatR;
using System.Collections.Generic;

namespace ProductService.Application.Queries.GetOrders
{
    public class GetOrderInputModel : IRequest<List<GetOrderViewModel>>
    {
        public int userId { get; set; }
    }
}
