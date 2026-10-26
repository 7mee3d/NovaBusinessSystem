
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record SalesPerformanceReportDTO(
        string ProductName,
        int Orders,
        int Units,
        decimal Revenue,
        string Performance
    );
}
