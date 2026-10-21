
namespace NovaBusinessSystem.DTOs.Products.Sales
{
    public class MonthlyProductSalesDTO
    {
        public string Month { get; private set; }
        public int Orders { get; private set; }
        public int Units { get; private set; }
        public decimal Revenue { get; private set; }
        public decimal ? Previous { get; private set; }
        public string Change { get; private set; }

        public MonthlyProductSalesDTO(
            string month,
            int orders,
            int units,
            decimal revenue,
            decimal ? previous,
            string change)
        {
            this.Month = month;
            this.Orders = orders;
            this.Units = units;
            this.Revenue = revenue;
            this.Previous = previous;
            this.Change = change;
        }
    }
}
