namespace NovaBusinessSystem.DTOs.Products.Sales;

public record ProductSalesHistoryDto(
    int SaleID,
    string SaleDate,
    string CustomerName,
    int Quantity,
    decimal UnitPrice,
    string Status
);