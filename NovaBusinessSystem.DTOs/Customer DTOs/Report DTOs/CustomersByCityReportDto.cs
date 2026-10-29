namespace NovaBusinessSystem.DTOs.Customers.Reports;

public record CustomersByCityReportDto(
    string City,
    int TotalCustomers
);