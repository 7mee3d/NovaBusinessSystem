namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record TopSellingProductReportDto(
        long Rank,
        string ProductName,
        string Category,
        int Units
    );
}