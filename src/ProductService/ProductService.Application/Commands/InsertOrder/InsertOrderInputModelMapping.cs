using AutoMapper;
using ProductService.Core.Enums;
using ProductService.Core.Models;
using System;

namespace ProductService.Application.Commands.InsertOrder
{
    public class InsertOrderInputModelMapping : Profile
    {
        public InsertOrderInputModelMapping()
        {
            CreateMap<InsertOrderInputModel, Order>()
                    .ForMember(dest =>
                        dest.UserId,
                        opt => opt.MapFrom(src => src.userId))
                    .ForMember(dest =>
                        dest.ProductId,
                        opt => opt.MapFrom(src => src.productId))
                    .ForMember(dest =>
                        dest.UserAddressId,
                        opt => opt.MapFrom(src => src.userAddressId))
                    .ForMember(dest =>
                        dest.OrderStatusId,
                        opt => opt.MapFrom(src => (char)StatusOrderEnum.PreparingProduct))
                    .ForMember(dest =>
                        dest.RegistrationDate,
                        opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
