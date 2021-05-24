namespace ProductService.Application.Queries.GetOrders
{
    public class GetOrderAddressViewModel
    {
        public int userAddressId { get; set; }
        public string address { get; set; }
        public int number { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string district { get; set; }
    }
}
