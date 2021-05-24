using AutoMapper;
using ProductService.Core.Models;

namespace ProductService.Application.Queries.GetOrders
{
    class GetOrderAddressViewModelMapping : Profile
    {
        public GetOrderAddressViewModelMapping()
        {
            CreateMap<UserAddress, GetOrderAddressViewModel>()
                   .ForMember(dest =>
                        dest.userAddressId,
                        opt => opt.MapFrom(src => src.UserAddressId))
                   .ForMember(dest =>
                        dest.address,
                        opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest =>
                        dest.number,
                        opt => opt.MapFrom(src => src.Number))
                    .ForMember(dest =>
                        dest.city,
                        opt => opt.MapFrom(src => src.City))
                    .ForMember(dest =>
                        dest.state,
                        opt => opt.MapFrom(src => src.State))
                    .ForMember(dest =>
                        dest.district,
                        opt => opt.MapFrom(src => src.District));
        }
    }
}
