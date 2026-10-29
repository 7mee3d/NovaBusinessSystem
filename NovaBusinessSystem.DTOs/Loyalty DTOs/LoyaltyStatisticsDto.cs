namespace NovaBusinessSystem.DTOs.Customers.Loyalty;
public record LoyaltyStatisticsDto(
    long TotalLoyaltyPoints,
    int MinimumPoints,
    int MaximumPoints,
    decimal AveragePoints,
    int DiamondCustomers,
    int PlatinumCustomers,
    int GoldCustomers,
    int SilverCustomers,
    int BronzeCustomers
);