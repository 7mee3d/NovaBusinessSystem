namespace NovaBusinessSystem.DTOs.Products.Sales;

public record TopSellingProductDto(
    long Rank,
    string ProductName,
    int UnitsSold,
    int Orders
);