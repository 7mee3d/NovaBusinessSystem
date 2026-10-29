
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record SalesPerformanceReportDto(
        string ProductName,
        int Orders,
        int Units,
        decimal Revenue,
        string Performance
    );
}
