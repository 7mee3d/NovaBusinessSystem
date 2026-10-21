
namespace NovaBusinessSystem.DTOs.Products.Sales
{
    public class ProductRevenueRankingDTO
    {
        public long Rank { get; private set; }
        public string ProductName { get; private set; }
        public int Units { get; private set; }
        public decimal RevenueFromCompletedSales { get; private set; }

        public ProductRevenueRankingDTO(
            long rank,
            string productName,
            int units,
            decimal revenue)
        {
            this.Rank = rank;
            this.ProductName = productName;
            this.Units = units;
            this.RevenueFromCompletedSales = revenue;
        }
    }
}