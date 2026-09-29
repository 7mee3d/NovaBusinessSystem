namespace NovaBusinessSystem.DTOs.Customers.Reports
{
    public class LoyaltySummaryDTO
    {
        public string LoyaltyLevel { get; private set; }
        public int Customers { get; private set; }
        public int TotalPoints { get; private set; }

        public LoyaltySummaryDTO(
            string loyaltyLevel,
            int customers,
            int totalPoints)
        {
            this.LoyaltyLevel = loyaltyLevel;
            this.Customers = customers;
            this.TotalPoints = totalPoints;
        }
    }
}