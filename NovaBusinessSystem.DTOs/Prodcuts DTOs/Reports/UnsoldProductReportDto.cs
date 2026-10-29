
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record UnsoldProductReportDto(
        int ProductID,
        string ProductName,
        string Category,
        int StockQuantity
    );
}
