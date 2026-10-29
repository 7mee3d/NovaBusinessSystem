
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IReportsService
{

    Task<IEnumerable<CustomerStatusReportDto>> GetCustomerStatusSummaryAsync();
    Task<IEnumerable<CustomersByCityReportDto>> GetCustomersByCityAsync();
    Task<IEnumerable<LoyaltyLevelSummaryReportDto>> GetLoyaltySummaryReportAsync();
    Task<IEnumerable<CustomerRegistrationSummaryDto>> GetRegistrationSummaryAsync();
}
