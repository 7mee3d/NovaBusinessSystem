
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record InventoryValuationDTO(
        string Category,
        int Products,
        int Units,
        decimal InventoryValue
    );
}
