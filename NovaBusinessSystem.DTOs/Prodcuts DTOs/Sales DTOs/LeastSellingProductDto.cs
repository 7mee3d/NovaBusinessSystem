namespace NovaBusinessSystem.DTOs.Products.Sales;

public record LeastSellingProductDto(
    long Rank,
    string ProductName,
    int UnitsSold,
    int Orders
);