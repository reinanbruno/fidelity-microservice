using AutoMapper;
using ProductService.Core.Models;

namespace ProductService.Application.Queries.FilterCategories
{
    public class FilterCategoriesViewModelMapping : Profile
    {
        public FilterCategoriesViewModelMapping()
        {
            CreateMap<Category, FilterCategoriesViewModel>()
                    .ForMember(dest =>
                        dest.id,
                        opt => opt.MapFrom(src => src.CategoryId))
                    .ForMember(dest =>
                        dest.name,
                        opt => opt.MapFrom(src => src.Name));
        }
    }
}
