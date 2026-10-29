namespace NovaBusinessSystem.DTOs.Customers.Loyalty;

public record CustomerPointsDto(
    int CustomerID,
    string CustomerName,
    int CurrentPoints,
    string LoyaltyLevel
);