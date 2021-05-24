using AutoMapper;
using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Queries.FilterCategories
{
    public class FilterCategoriesQueryHandler : IRequestHandler<FilterCategoriesInputModel, List<FilterCategoriesViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public FilterCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<FilterCategoriesViewModel>> Handle(FilterCategoriesInputModel request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository.Filter(request.description);
            return _mapper.Map<List<FilterCategoriesViewModel>>(categories);
        }
    }
}
