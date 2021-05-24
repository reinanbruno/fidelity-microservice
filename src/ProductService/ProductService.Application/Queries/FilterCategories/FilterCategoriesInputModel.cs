using MediatR;
using System.Collections.Generic;

namespace ProductService.Application.Queries.FilterCategories
{
    public class FilterCategoriesInputModel : IRequest<List<FilterCategoriesViewModel>>
    {
        public string description { get; set; }
    }
}
