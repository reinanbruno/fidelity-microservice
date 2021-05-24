using AutoMapper;
using ProductService.Core.Models;

namespace ProductService.Application.Queries.FilterProducts
{
    public class FilterProductsViewModelMapping : Profile
    {
        public FilterProductsViewModelMapping()
        {
            CreateMap<Product, FilterProductsViewModel>()
                    .ForMember(dest =>
                        dest.productId,
                        opt => opt.MapFrom(src => src.ProductId))
                    .ForMember(dest =>
                        dest.product,
                        opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest =>
                        dest.subcategory,
                        opt => opt.MapFrom(src => src.Subcategory.Name))
                    .ForMember(dest =>
                        dest.category,
                        opt => opt.MapFrom(src => src.Subcategory.Category.Name))
                    .ForMember(dest =>
                        dest.pointsValue,
                        opt => opt.MapFrom(src => src.PointsValue));
        }
    }
}
