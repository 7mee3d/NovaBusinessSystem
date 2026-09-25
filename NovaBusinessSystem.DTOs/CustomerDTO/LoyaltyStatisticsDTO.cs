namespace NovaBusinessSystem.DTOs
{

    public class LoyaltyStatisticsDTO
    {
        public long TotalLoyaltyPoints { get; private set; }

        public int MinimumPoints { get; private set; }

        public int MaximumPoints { get; private set; }

        public decimal AveragePoints { get; private set; }

        public int DiamondCustomers { get; private set; }

        public int PlatinumCustomers { get; private set; }

        public int GoldCustomers { get; private set; }

        public int SilverCustomers { get; private set; }

        public int BronzeCustomers { get; private set; }

        public LoyaltyStatisticsDTO(
            long totalLoyaltyPoints,
            int minimumPoints,
            int maximumPoints,
            decimal averagePoints,
            int diamondCustomers,
            int platinumCustomers,
            int goldCustomers,
            int silverCustomers,
            int bronzeCustomers)
        {
            this.TotalLoyaltyPoints = totalLoyaltyPoints;
            this.MinimumPoints = minimumPoints;
            this.MaximumPoints = maximumPoints;
            this.AveragePoints = averagePoints;
            this.DiamondCustomers = diamondCustomers;
            this.PlatinumCustomers = platinumCustomers;
            this.GoldCustomers = goldCustomers;
            this.SilverCustomers = silverCustomers;
            this.BronzeCustomers = bronzeCustomers;
        }
    }
}