
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record StockLevelReportDTO(
        string ProductName,
        int StockQuantity,
        string StockLevel
    );
}
