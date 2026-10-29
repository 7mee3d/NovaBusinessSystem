
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record CategoryRevenueReportDto(
        long Rank,
        string Category,
        int Orders,
        int Units,
        decimal Revenue
    );
}
