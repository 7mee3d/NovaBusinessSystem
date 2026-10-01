using NovaBusinessSystem.DAL.Products;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.BL.Products
{
    public class Product
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public string Status { get; private set; }
        public ProductDTO ProductDto { get; private set; }

        public Product(

            int productID,
            string productName,
            string category,
            decimal price,
            int stockQuantity,
            string status

            )
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.Status = status;
        }

        public async static Task<IEnumerable<ProductDTO>> GetAllProductsAsync() => await ProductsDAL.GetAllProductsAsync();


    }
}