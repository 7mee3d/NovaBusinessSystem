
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record StockLevelReportDto(
        string ProductName,
        int StockQuantity,
        string StockLevel
    );
}
