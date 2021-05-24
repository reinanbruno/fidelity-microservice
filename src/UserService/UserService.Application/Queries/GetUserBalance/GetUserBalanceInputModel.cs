using MediatR;

namespace UserService.Application.Queries.GetUserBalance
{
    public class GetUserBalanceInputModel : IRequest<decimal>
    {
        public int userId { get; set; }
    }
}
