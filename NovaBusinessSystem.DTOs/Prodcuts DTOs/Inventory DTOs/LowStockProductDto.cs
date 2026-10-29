namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record LowStockProductDto(
    int ProductID,
    string ProductName,
    string Category,
    int StockQuantity,
    string Status
);