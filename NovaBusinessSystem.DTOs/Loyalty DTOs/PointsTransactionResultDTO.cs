namespace NovaBusinessSystem.DTOs
{

    public class PointsTransactionResultDTO
    {
        public string CustomerName { get; private set; } = string.Empty;
        public int PreviousPoints { get; private set; }
        public int Points { get; private set; }
        public int NewBalance { get; private set; }

        public PointsTransactionResultDTO(
            string customerName,
            int previousPoints,
            int points ,
            int newBalance
            
            )
        {
            this.CustomerName = customerName;
            this.PreviousPoints = previousPoints;
            this.Points = points;
            this.NewBalance = newBalance ; 

        }
    }
}