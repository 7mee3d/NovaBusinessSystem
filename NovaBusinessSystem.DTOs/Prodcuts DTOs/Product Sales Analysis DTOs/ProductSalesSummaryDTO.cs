
namespace NovaBusinessSystem.DTOs.Products.Sales
{
    public class ProductSalesSummaryDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public int Orders { get; private set; }
        public int UnitsSold { get; private set; }
        public decimal Revenue { get; private set; }
        public decimal AverageQty { get; private set; }
        public decimal AverageRevenue { get; private set; }

        public ProductSalesSummaryDTO(
            int productID,
            string productName,
            string category,
            int orders,
            int unitsSold,
            decimal revenue,
            decimal averageQty,
            decimal averageRevenue)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.Orders = orders;
            this.UnitsSold = unitsSold;
            this.Revenue = revenue;
            this.AverageQty = averageQty;
            this.AverageRevenue = averageRevenue;
        }
    }
}
