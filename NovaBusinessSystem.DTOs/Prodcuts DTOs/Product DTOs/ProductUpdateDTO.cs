namespace NovaBusinessSystem.DTOs.Products
{
    public class ProductUpdateDTO
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public ProductUpdateDTO(
            string productName,
            string category,
            decimal price,
            string status)
        {
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.Status = status;
        }
    }
}