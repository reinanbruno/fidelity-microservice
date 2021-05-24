using MediatR;
using System;
using System.Collections.Generic;

namespace UserService.Application.Queries.GetUserExtract
{
    public class GetUserExtractInputModel : IRequest<List<GetUserExtractViewModel>>
    {
        public int userId { get; set; }
        public DateTime initial_date { get; set; }
        public DateTime final_date { get; set; }
    }
}
