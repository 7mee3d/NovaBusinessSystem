namespace NovaBusinessSystem.DTOs.Customers.Reports;

public record CustomerStatusReportDto(
    string Status,
    int TotalCustomers
);