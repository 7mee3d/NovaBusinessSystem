using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.BL.Services;


public class ReportsService : IReportsService
{
    private readonly IReportsRepository _repository;

    public ReportsService(IReportsRepository reportsRepository)
    {
        this._repository = reportsRepository ?? throw new ArgumentNullException(nameof(reportsRepository));
    }

    public Task<IEnumerable<CustomersByCityReportDto>> GetCustomersByCityAsync()
    {
        return _repository.GetCustomersByCityAsync();
    }

    public Task<IEnumerable<CustomerStatusReportDto>> GetCustomerStatusSummaryAsync()
    {
        return _repository.GetCustomerStatusSummaryAsync();
    }

    public Task<IEnumerable<LoyaltyLevelSummaryReportDto>> GetLoyaltySummaryReportAsync()
    {
        return _repository.GetLoyaltySummaryReportAsync();
    }

    public Task<IEnumerable<CustomerRegistrationSummaryDto>> GetRegistrationSummaryAsync()
    {
        return _repository.GetRegistrationSummaryAsync();
    }
}