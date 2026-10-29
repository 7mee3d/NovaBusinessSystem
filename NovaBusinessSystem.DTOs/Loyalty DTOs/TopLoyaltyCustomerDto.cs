namespace NovaBusinessSystem.DTOs.Customers.Loyalty;

public record TopLoyaltyCustomerDto(
    long Rank,
    string CustomerName,
    int Points,
    string Level
);