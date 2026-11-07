namespace NovaBusinessSystem.DTOs.Products.Sales;

public record ProductRevenueRankingDto(
    long Rank,
    string ProductName,
    int UnitsSold,
    decimal RevenueFromCompletedSales
);