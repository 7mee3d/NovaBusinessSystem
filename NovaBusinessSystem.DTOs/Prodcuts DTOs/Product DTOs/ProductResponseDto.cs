namespace NovaBusinessSystem.DTOs.Products;

public record ProductResponseDto(
    int ProductID,
    string ProductName,
    string Category,
    decimal Price,
    int StockQuantity,
    string Status
);