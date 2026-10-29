
using NovaBusinessSystem.DTOs.Customers.Reports;


namespace NovaBusinessSystem.BL.Interfaces;

public interface IReportsRepository
{

Task<IEnumerable<CustomerStatusReportDto>> GetCustomerStatusSummaryAsync();
Task<IEnumerable<CustomersByCityReportDto>> GetCustomersByCityAsync();
Task<IEnumerable<LoyaltyLevelSummaryReportDto>> GetLoyaltySummaryReportAsync();
Task<IEnumerable<CustomerRegistrationSummaryDto>> GetRegistrationSummaryAsync();
}
