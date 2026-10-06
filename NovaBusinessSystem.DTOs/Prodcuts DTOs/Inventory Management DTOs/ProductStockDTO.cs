namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class ProductStockDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public decimal StockValue { get; private set; }
        public string Status { get; private set; }

        public ProductStockDTO(
            int productID,
            string productName,
            string category,
            decimal price,
            int stockQuantity,
            decimal stockValue,
            string status)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.StockValue = stockValue;
            this.Status = status;
        }
    }
}