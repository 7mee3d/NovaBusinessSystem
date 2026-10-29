using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Inventory;

namespace NovaBusinessSystem.BL.Services;

public class InventoryService : IInventoryService
{

    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository inventoryRepository)
    {
        this._repository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
    }

    public Task<AddStockResultDto?> AddStockAsync(int productID, int stockToAdded)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(stockToAdded);

        return this._repository.AddStockAsync(productID, stockToAdded);
    }

    public Task<AdjustStockResultDto?> AdjustStockAsync(int productID, int actualStock)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(actualStock);

        return this._repository.AdjustStockAsync(productID, actualStock);
    }

    public Task<InventoryValueDto?> GetInventoryValueAsync()
    {
        return this._repository.GetInventoryValueAsync();
    }

    public Task<IEnumerable<LowStockProductDto>> GetLowStockProducts(int threshold)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(threshold);

        return this._repository.GetLowStockProducts(threshold);

    }

    public Task<IEnumerable<OutOfStockProductDto>> GetOutOfStockProducts()
    {
        return this._repository.GetOutOfStockProducts();
    }

    public Task<RemoveStockResultDto?> RemoveStockAsync(int productID, int stockToBeRemove)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(stockToBeRemove);

        return this._repository.RemoveStockAsync(productID, stockToBeRemove);
    }

    public Task<ProductStockResponseDto?> ViewProductStockAsync(int productID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);

        return this._repository.ViewProductStockAsync(productID);

    }
}