using System;

namespace ProductService.Application.Queries.GetOrders
{
    public class GetOrderViewModel
    {
        public int orderId { get; set; }
        public string product { get; set; }
        public decimal pointsValue { get; set; }
        public string status { get; set; }
        public string registrationDate { get; set; }
        public GetOrderAddressViewModel userAddress { get; set; }
    }
}
