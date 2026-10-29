namespace NovaBusinessSystem.DTOs.Customers.Reports;

public record LoyaltyLevelSummaryReportDto(
    string LoyaltyLevel,
    int TotalCustomers,
    long TotalLoyaltyPoints
);