using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IProductsRepository
{
    Task<IEnumerable<ProductResponseDto?>> GetAllAsync();
    Task<ProductResponseDto?> GetProductByIDAsync(int productID);
    Task<int> AddProductAsync(ProductCreateRequestDto product);
    Task<bool> UpdateProductAsync(int productID, ProductUpdateRequestDto product);
    Task<bool> DeleteProductAsync(int productID);

}