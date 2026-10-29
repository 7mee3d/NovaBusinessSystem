
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record SlowMovingProductReportDto(
        string ProductName,
        string Category,
        int UnitsSold
    );
}
