namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerSpendingSummaryDto(
    int TotalOrders,
    int CompletedOrders,
    int PendingOrders,
    int CancelledOrders,
    decimal TotalSpent,
    decimal AverageOrderValue,
    decimal LargestOrderValue,
    DateTime? FirstPurchaseDate,
    DateTime? LastPurchaseDate
);