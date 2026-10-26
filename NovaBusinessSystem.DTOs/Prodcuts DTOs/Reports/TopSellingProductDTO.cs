namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record TopSellingProductDTO(
        long Rank,
        string ProductName,
        string Category,
        int Units
    );
}