namespace NovaBusinessSystem.DTOs
{

    public class MonthlyPurchaseDTO
    {
        public string Month { get; private set; }
        public int Orders { get; private set; }
        public decimal TotalSpent { get; private set; }

        public MonthlyPurchaseDTO(
            string month,
            int orders,
            decimal totalSpent)
        {
            this.Month = month;
            this.Orders = orders;
            this.TotalSpent = totalSpent;
        }
    }
}