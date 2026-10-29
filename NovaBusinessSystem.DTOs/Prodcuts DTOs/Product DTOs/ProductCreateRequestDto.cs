namespace NovaBusinessSystem.DTOs.Products;

public record ProductCreateRequestDto(
    string ProductName,
    string Category,
    decimal Price,
    int StockQuantity,
    string Status
);