
namespace NovaBusinessSystem.DTOs.Products.Sales;

public record CategoryPerformanceDto(
    string Category,
    int Products,
    int UnitsSold,
    decimal Revenue
);
