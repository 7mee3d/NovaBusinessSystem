namespace NovaBusinessSystem.DTOs
{
    public class CustomerRankingDTO
    {
        public long Rank { get; private set; }
        public string FullName { get; private set; }
        public int Orders { get; private set; }
        public decimal Spending { get; private set; }

        public CustomerRankingDTO(
            long rank,
            string fullName,
            int orders,
            decimal spending)
        {
            this.Rank = rank;
            this.FullName = fullName;
            this.Orders = orders;
            this.Spending = spending;
        }
    }
}