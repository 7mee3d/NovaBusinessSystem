
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record InventoryValuationReportDto(
        string Category,
        int Products,
        int Units,
        decimal InventoryValue
    );
}
