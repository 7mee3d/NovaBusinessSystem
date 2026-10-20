
namespace NovaBusinessSystem.DTOs.Products.Sales
{
    public class LeastSellingProductDTO
    {
        public long Rank { get; private set; }
        public string ProductName { get; private set; }
        public int UnitsSold { get; private set; }
        public int Orders { get; private set; }

        public LeastSellingProductDTO(
            long rank,
            string productName,
            int unitsSold,
            int orders)
        {
            this.Rank = rank;
            this.ProductName = productName;
            this.UnitsSold = unitsSold;
            this.Orders = orders;
        }
    }
}
