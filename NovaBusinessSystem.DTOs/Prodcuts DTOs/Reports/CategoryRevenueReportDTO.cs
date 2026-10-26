
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record CategoryRevenueReportDTO(
        long Rank,
        string Category,
        int Orders,
        int Units,
        decimal Revenue
    );
}
