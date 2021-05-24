using MediatR;
using System.Collections.Generic;

namespace ProductService.Application.Queries.FilterSubCategories
{
    public class FilterSubCategoriesInputModel : IRequest<List<FilterSubCategoriesViewModel>>
    {
        public int? categoryId { get; set; }
        public string description { get; set; }
    }
}
