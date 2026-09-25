namespace NovaBusinessSystem.DTOs
{


    public class TopLoyaltyCustomerDTO
    {
        public long Rank { get; }
        public string CustomerName { get; }
        public int Points { get; }
        public string Level { get; }

        public TopLoyaltyCustomerDTO(
            long rank,
            string customerName,
            int points,
            string level)
        {
            this.Rank = rank;
            this.CustomerName = customerName;
            this.Points = points;
            this.Level = level;
        }
    }
}