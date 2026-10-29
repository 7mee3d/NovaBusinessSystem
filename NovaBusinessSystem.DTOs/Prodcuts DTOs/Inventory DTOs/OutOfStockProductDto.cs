namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record OutOfStockProductDto(
    int ProductID,
    string ProductName,
    string Category,
    string Status
);