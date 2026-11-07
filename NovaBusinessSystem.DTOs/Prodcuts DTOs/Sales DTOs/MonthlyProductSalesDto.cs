namespace NovaBusinessSystem.DTOs.Products.Sales;

public record MonthlyProductSalesDto(
    string Month,
    int Orders,
    int Units,
    decimal Revenue,
    decimal? PreviousRevenue,
    string Change
);