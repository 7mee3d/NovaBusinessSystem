namespace NovaBusinessSystem.DTOs.Customers;

public record FavoriteProductDto(
    long Rank,
    string ProductName,
    int TotalQuantityPurchased
);