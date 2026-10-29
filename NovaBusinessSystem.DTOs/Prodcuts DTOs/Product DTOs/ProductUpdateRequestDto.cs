namespace NovaBusinessSystem.DTOs.Products;

public record ProductUpdateRequestDto(
    string ProductName,
    string Category,
    decimal Price,
    string Status
);