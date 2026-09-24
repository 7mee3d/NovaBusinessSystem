namespace NovaBusinessSystem.DTOs
{

    public class CustomerPointsDTO
    {
        public int CustomerID { get; private set; }
        public string CustomerName { get; private set; } = string.Empty;
        public int CurrentPoints { get; private set; }
        public string LoyaltyLevel { get; private set; } = string.Empty;

        public CustomerPointsDTO(
            int customerID ,
            string customerName,
            int currentPoints,
            string loyaltyLevel)
        {
            this.CustomerID = customerID ;
            this.CustomerName = customerName;
            this.CurrentPoints = currentPoints;
            this.LoyaltyLevel = loyaltyLevel;
        }
    }
}