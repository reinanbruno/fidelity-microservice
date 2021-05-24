using ProductService.Application.Commands.Contract;
using MediatR;

namespace ProductService.Application.Commands.InsertOrder
{
    public class InsertOrderInputModel : IRequest<ICommandResult<int>>
    {
        public int userId { get; set; }
        public int userAddressId { get; set; }
        public int productId { get; set; }
    }
}
