namespace NovaBusinessSystem.DTOs.Customers;

public record MonthlyPurchaseSummaryDto(
    string Month,
    int TotalOrders,
    decimal TotalSpent
);