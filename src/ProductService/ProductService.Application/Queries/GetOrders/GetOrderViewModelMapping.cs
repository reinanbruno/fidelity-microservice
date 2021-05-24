using AutoMapper;
using ProductService.Core.Models;

namespace ProductService.Application.Queries.GetOrders
{
    class GetOrderViewModelMapping : Profile
    {
        public GetOrderViewModelMapping()
        {
            CreateMap<Order, GetOrderViewModel>()
                    .ForMember(dest =>
                        dest.orderId,
                        opt => opt.MapFrom(src => src.OrderId))
                    .ForMember(dest =>
                        dest.product,
                        opt => opt.MapFrom(src => src.Product.Name))
                    .ForMember(dest =>
                        dest.pointsValue,
                        opt => opt.MapFrom(src => src.PointsValue))
                    .ForMember(dest =>
                        dest.status,
                        opt => opt.MapFrom(src => src.OrderStatus.Description))
                    .ForMember(dest =>
                        dest.userAddress,
                        opt => opt.MapFrom(src => src.UserAddress))
                    .ForMember(dest =>
                        dest.registrationDate,
                        opt => opt.MapFrom(src => src.RegistrationDate.ToString("dd/MM/yyyy HH:mm:ss")));
        }
    }
}
