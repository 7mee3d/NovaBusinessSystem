namespace NovaBusinessSystem.DTOs.Products.Reports;

public record TopSellingProductReportDto(
    long Rank,
    string ProductName,
    int UnitsSold,
    int Orders
);