namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class OutOfStockProductDTO
    {

        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public string Status { get; private set; }

        public OutOfStockProductDTO(
            int productID,
            string productName,
            string category,
            string status)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.Status = status;
        }
    }
}