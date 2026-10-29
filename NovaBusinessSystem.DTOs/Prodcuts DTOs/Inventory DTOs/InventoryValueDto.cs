namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record InventoryValueDto(
    int TotalProducts,
    int TotalStockUnits,
    decimal TotalInventoryValue,
    decimal AverageProductPrice,
    decimal AverageStock,
    string MostValuableStock,
    decimal StockValue
);