namespace NovaBusinessSystem.DTOs
{

    public class FavoriteProductDTO
    {
        public long Rank { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }

        public FavoriteProductDTO(
            long rank,
            string productName,
            int quantity)
        {
            this.Rank = rank;
            this.ProductName = productName;
            this.Quantity = quantity;
        }
    }

}