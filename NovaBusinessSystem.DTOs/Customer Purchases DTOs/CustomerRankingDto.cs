namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerRankingDto(
    long Rank,
    string CustomerName,
    int TotalOrders,
    decimal TotalSpent
);