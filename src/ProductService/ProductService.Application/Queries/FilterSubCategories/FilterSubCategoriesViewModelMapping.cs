using AutoMapper;
using ProductService.Core.Models;

namespace ProductService.Application.Queries.FilterSubCategories
{
    public class FilterSubCategoriesViewModelMapping : Profile
    {
        public FilterSubCategoriesViewModelMapping()
        {
            CreateMap<Subcategory, FilterSubCategoriesViewModel>()
                    .ForMember(dest =>
                        dest.subCategoryId,
                        opt => opt.MapFrom(src => src.SubcategoryId))
                    .ForMember(dest =>
                        dest.categoryId,
                        opt => opt.MapFrom(src => src.CategoryId))
                    .ForMember(dest =>
                        dest.categoryName,
                        opt => opt.MapFrom(src => src.Category.Name))
                    .ForMember(dest =>
                        dest.subCategoryName,
                        opt => opt.MapFrom(src => src.Name));
        }
    }
}
