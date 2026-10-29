namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record ProductStockResponseDto(
    int ProductID,
    string ProductName,
    string Category,
    decimal Price,
    int StockQuantity,
    decimal StockValue,
    string Status
);