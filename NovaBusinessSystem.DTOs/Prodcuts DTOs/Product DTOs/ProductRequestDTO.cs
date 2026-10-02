namespace NovaBusinessSystem.DTOs.Products
{
    public class ProductRequestDTO
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }

        public ProductRequestDTO(
            string productName,
            string category,
            decimal price,
            int stockQuantity,
            string status)
        {
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.Status = status;
        }
    }

}