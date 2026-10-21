
namespace NovaBusinessSystem.DTOs.Products.Sales
{
    public class CategoryPerformanceDTO
    {
        public string Category { get; private set; }
        public int Products { get; private set; }
        public int UnitsSold { get; private set; }
        public decimal Revenue { get; private set; }

        public CategoryPerformanceDTO(
            string category,
            int products,
            int unitsSold,
            decimal revenue)
        {
            this.Category = category;
            this.Products = products;
            this.UnitsSold = unitsSold;
            this.Revenue = revenue;
        }
    }
}
