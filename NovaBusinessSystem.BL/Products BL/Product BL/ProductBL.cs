using NovaBusinessSystem.DAL.Products;
using NovaBusinessSystem.DTOs.Products;
using NovaBusinessSystem.Enumeration;

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
        public ProductDTO ProductDto
        {
            get
            {
                return new ProductDTO(
                    this.ProductID,
                    this.ProductName,
                    this.Category,
                    this.Price,
                    this.StockQuantity,
                    this.Status
                    );
            }


        }

        public Enumerations.EnMode enMode { get; private set; }


        public Product(ProductDTO productDto, Enumerations.EnMode mode)
        {
            this.ProductID = productDto.ProductID;
            this.ProductName = productDto.ProductName;
            this.Category = productDto.Category;
            this.Price = productDto.Price;
            this.StockQuantity = productDto.StockQuantity;
            this.Status = productDto.Status;
            this.enMode = mode;

        }

        public Product(ProductRequestDTO productDto, Enumerations.EnMode mode)
        {

            this.ProductName = productDto.ProductName;
            this.Category = productDto.Category;
            this.Price = productDto.Price;
            this.StockQuantity = productDto.StockQuantity;
            this.Status = productDto.Status;
            this.enMode = mode;

        }

        public void Update(ProductUpdateDTO productDto)
        {

            this.ProductName = productDto.ProductName;
            this.Category = productDto.Category;
            this.Price = productDto.Price;
            this.Status = productDto.Status;
        }

        public Product()
        {
            this.ProductID = -1;
            this.ProductName = string.Empty;
            this.Category = string.Empty;
            this.Price = 0.0m;
            this.StockQuantity = -1;
            this.Status = string.Empty;

            this.enMode = Enumerations.EnMode._kADD;
        }


        public async static Task<IEnumerable<ProductDTO>>? GetAllProductsAsync() => await ProductsDAL.GetAllProductsAsync()!;

        public async static Task<Product> GetProductByIDAsync(int productID)
        {
            if (productID <= 0)
                throw new Exception("Invalid Data");

            ProductDTO productDto = await ProductsDAL.GetProductByIDAsync(productID)!;

            if (productDto is null)
                return null!;

            return new Product(
                productDto,
                Enumerations.EnMode._kUPDATE
                );

        }

        private async Task<bool>? _AddNewProduct()
        {
            this.ProductID = await ProductsDAL.AddNewProductAsync(this.ProductDto)!;
            return this.ProductID > 0;
        }
        private async Task<bool>? _UpdateProduct()
        {
            ProductUpdateDTO productUpdate = new ProductUpdateDTO(this.ProductName, this.Category, this.Price, this.Status);

            int rowAffective = await ProductsDAL.UpdateProductAsync(this.ProductID, productUpdate)!;
            return rowAffective > 0;
        }

        public async Task<bool>  SaveMode()
        {
            switch (this.enMode)
            {
                case Enumerations.EnMode._kADD:
                    {
                        if (await _AddNewProduct()!)
                        {
                            this.enMode = Enumerations.EnMode._kUPDATE;
                            return true;
                        }
                        return false;
                    }

                case Enumerations.EnMode._kUPDATE:
                    return await _UpdateProduct()!;

                default: return false;
            }
        }

        public async Task<bool> ? DeleteProduct ()
        => await ProductsDAL.DeleteProductAsync(this.ProductID)!;
    }
}