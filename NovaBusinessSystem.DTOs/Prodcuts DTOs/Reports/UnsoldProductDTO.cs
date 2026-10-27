
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record UnsoldProductDTO(
        int ProductID,
        string ProductName,
        string Category,
        int StockQuantity
    );
}
