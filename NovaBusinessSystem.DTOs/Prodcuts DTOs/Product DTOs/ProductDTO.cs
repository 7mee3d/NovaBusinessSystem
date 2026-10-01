namespace NovaBusinessSystem.DTOs.Products
{
    public class ProductDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public string Status { get; private set; }

        public ProductDTO(
            int productID,
            string productName,
            string category,
            decimal price,
            int stockQuantity,
            string status)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.Status = status;
        }
    }
}