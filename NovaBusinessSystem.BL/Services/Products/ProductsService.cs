using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.BL.Services;

public class ProductsService : IProductsService
{

    private readonly IProductsRepository _repository;

    public ProductsService(IProductsRepository productsRepository)
    {
        this._repository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
    }

    public Task<IEnumerable<ProductResponseDto?>> GetAllAsync()
    {
        return this._repository.GetAllAsync();
    }

    public Task<ProductResponseDto?> GetProductByIDAsync(int productID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);
        return _repository.GetProductByIDAsync(productID);

    }

    public Task<int> AddProductAsync(ProductCreateRequestDto product)
    {
        ArgumentNullException.ThrowIfNull(product);

        return _repository.AddProductAsync(product);
    }

    public Task<bool> UpdateProductAsync(int productID, ProductUpdateRequestDto product)
    {
        ArgumentNullException.ThrowIfNull(product);

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);

        return _repository.UpdateProductAsync(productID, product);

    }

    public Task<bool> DeleteProductAsync(int productID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);


        return _repository.DeleteProductAsync(productID);
    }

}