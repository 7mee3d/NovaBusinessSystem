using NovaBusinessSystem.DTOs.Products.Inventory;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IInventoryService
{
    Task<ProductStockResponseDto?> ViewProductStockAsync(int productID);
    Task<AddStockResultDto?> AddStockAsync(int productID, int stockToAdded);
    Task<RemoveStockResultDto?> RemoveStockAsync(int productID, int stockToBeRemove);
    Task<AdjustStockResultDto?> AdjustStockAsync(int productID, int actualStock);
    Task<IEnumerable<LowStockProductDto>> GetLowStockProducts(int threshold);
    Task<IEnumerable<OutOfStockProductDto>> GetOutOfStockProducts();
    Task<InventoryValueDto?> GetInventoryValueAsync();

}