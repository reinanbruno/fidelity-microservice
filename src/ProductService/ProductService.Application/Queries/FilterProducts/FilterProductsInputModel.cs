using MediatR;
using System.Collections.Generic;

namespace ProductService.Application.Queries.FilterProducts
{
    public class FilterProductsInputModel : IRequest<List<FilterProductsViewModel>>
    {
        public int? categoryId { get; set; }
        public int? subcategoryId { get; set; }
    }
}
