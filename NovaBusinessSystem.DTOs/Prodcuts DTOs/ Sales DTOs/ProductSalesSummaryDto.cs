namespace NovaBusinessSystem.DTOs.Products.Sales;

public record ProductSalesSummaryDto(
    int ProductID,
    string ProductName,
    string Category,
    int Orders,
    int UnitsSold,
    decimal Revenue,
    decimal AverageQuantity,
    decimal AverageRevenue
);