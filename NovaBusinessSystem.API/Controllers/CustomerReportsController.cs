using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.API.Controllers.Customers;

[ApiController]
[Route("api/customers/reports")]
public class CustomersReportController : ControllerBase
{
    private readonly IReportsService _reportsService;

    public CustomersReportController(IReportsService reportsService)
    {
        _reportsService = reportsService
            ?? throw new ArgumentNullException(nameof(reportsService));
    }

    [HttpGet("status", Name = "GetCustomerStatusSummary")]
    [ProducesResponseType(typeof(IEnumerable<CustomerStatusReportDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomerStatusReportDto>>> GetCustomerStatusSummaryAsync()
    {
        var customerStatuses = await _reportsService.GetCustomerStatusSummaryAsync();

        return Ok(customerStatuses);
    }

    [HttpGet("cities", Name = "GetCustomersByCity")]
    [ProducesResponseType(typeof(IEnumerable<CustomersByCityReportDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomersByCityReportDto>>> GetCustomersByCityAsync()
    {
        var customersByCity = await _reportsService.GetCustomersByCityAsync();

        return Ok(customersByCity);
    }

    [HttpGet("loyalty", Name = "GetLoyaltySummaryReport")]
    [ProducesResponseType(typeof(IEnumerable<LoyaltyLevelSummaryReportDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<LoyaltyLevelSummaryReportDto>>> GetLoyaltySummaryReportAsync()
    {
        var loyaltySummary = await _reportsService.GetLoyaltySummaryReportAsync();

        return Ok(loyaltySummary);
    }

    [HttpGet("registrations", Name = "GetCustomerRegistrationSummary")]
    [ProducesResponseType(typeof(IEnumerable<CustomerRegistrationSummaryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomerRegistrationSummaryDto>>> GetRegistrationSummaryAsync()
    {
        var registrationSummary = await _reportsService.GetRegistrationSummaryAsync();

        return Ok(registrationSummary);
    }
}