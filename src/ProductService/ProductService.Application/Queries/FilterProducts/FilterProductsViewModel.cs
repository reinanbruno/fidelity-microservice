namespace ProductService.Application.Queries.FilterProducts
{
    public class FilterProductsViewModel
    {
        public int productId { get; init; }
        public string product { get; init; }
        public string category { get; init; }
        public string subcategory { get; init; }
        public decimal pointsValue { get; init; }
    }
}
