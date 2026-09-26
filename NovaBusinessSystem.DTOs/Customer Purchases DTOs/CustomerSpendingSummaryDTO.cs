namespace NovaBusinessSystem.DTOs
{

    public class CustomerSpendingSummaryDTO
    {
        public int TotalOrders { get; private set; }
        public int Completed { get; private set; }
        public int Pending { get; private set; }
        public int Cancelled { get; private set; }
        public string TotalSpent { get; private set; }
        public string AverageOrder { get; private set; }
        public string LargestOrder { get; private set; }
        public string FirstPurchase { get; private set; }
        public string LastPurchase { get; private set; }

        public CustomerSpendingSummaryDTO(

            int totalOrders,
            int completed,
            int pending,
            int cancelled,
            string totalSpent,
            string averageOrder,
            string largestOrder,
            string firstPurchase,
            string lastPurchase

            )
        {
            this.TotalOrders = totalOrders;
            this.Completed = completed;
            this.Pending = pending;
            this.Cancelled = cancelled;
            this.TotalSpent = totalSpent;
            this.AverageOrder = averageOrder;
            this.LargestOrder = largestOrder;
            this.FirstPurchase = firstPurchase;
            this.LastPurchase = lastPurchase;
        }
    }
}