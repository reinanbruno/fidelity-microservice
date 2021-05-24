using AutoMapper;
using ProductService.Core.Models;

namespace ProductService.Application.Queries.GetOrderTracking
{
    class GetOrderTrackingViewModelMapping : Profile
    {
        public GetOrderTrackingViewModelMapping()
        {
            CreateMap<OrderHistory, GetOrderTrackingViewModel>()
                    .ForMember(dest =>
                        dest.details,
                        opt => opt.MapFrom(src => src.Details))
                    .ForMember(dest =>
                        dest.status,
                        opt => opt.MapFrom(src => src.OrderStatus.Description))
                    .ForMember(dest =>
                        dest.registrationDate,
                        opt => opt.MapFrom(src => src.RegistrationDate.ToString("dd/MM/yyyy HH:mm:ss")));
        }
    }
}

