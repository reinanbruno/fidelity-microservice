using AutoMapper;
using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Queries.FilterProducts
{
    public class FilterProductsQueryHandler : IRequestHandler<FilterProductsInputModel, List<FilterProductsViewModel>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public FilterProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<FilterProductsViewModel>> Handle(FilterProductsInputModel request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productRepository.Filter(request.categoryId, request.subcategoryId);
            return _mapper.Map<List<FilterProductsViewModel>>(products);
        }
    }
}
