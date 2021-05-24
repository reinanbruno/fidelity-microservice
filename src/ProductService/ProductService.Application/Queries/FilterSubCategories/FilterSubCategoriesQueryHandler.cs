using AutoMapper;
using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Queries.FilterSubCategories
{
    public class FilterSubCategoriesQueryHandler : IRequestHandler<FilterSubCategoriesInputModel, List<FilterSubCategoriesViewModel>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public FilterSubCategoriesQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<FilterSubCategoriesViewModel>> Handle(FilterSubCategoriesInputModel request, CancellationToken cancellationToken)
        {
            List<Subcategory> subCategories = await _subCategoryRepository.Filter(request.categoryId, request.description);
            return _mapper.Map<List<FilterSubCategoriesViewModel>>(subCategories);
        }
    }
}
