
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record SlowMovingProductDTO(
        string ProductName,
        string Category,
        int UnitsSold
    );
}
