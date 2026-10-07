namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class LowStockProductDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public int StockQuantity { get; private set; }
        public string Status { get; private set; }

        public LowStockProductDTO(
            int productID,
            string productName,
            string category,
            int stockQuantity,
            string status)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.StockQuantity = stockQuantity;
            this.Status = status;
        }
    }
}