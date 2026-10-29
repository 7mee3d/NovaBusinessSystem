using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.DAL.Repositories;

public class ReportsRepository : IReportsRepository
{

    public async Task<IEnumerable<CustomerStatusReportDto>> GetCustomerStatusSummaryAsync()
    {
        var customerStatuses = new List<CustomerStatusReportDto>();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomerStatusSummary]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var statusOrdinal = reader.GetOrdinal("Status");
        var totalCustomersOrdinal = reader.GetOrdinal("Customers");

        while (await reader.ReadAsync())
        {
            customerStatuses.Add(new CustomerStatusReportDto(
                reader.GetString(statusOrdinal),
                reader.GetInt32(totalCustomersOrdinal)
            ));
        }

        return customerStatuses;
    }

    public async Task<IEnumerable<CustomersByCityReportDto>> GetCustomersByCityAsync()
    {
        var customersByCity = new List<CustomersByCityReportDto>();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomersByCity]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var cityOrdinal = reader.GetOrdinal("City");
        var totalCustomersOrdinal = reader.GetOrdinal("Customers");

        while (await reader.ReadAsync())
        {
            customersByCity.Add(new CustomersByCityReportDto(
                reader.GetString(cityOrdinal),
                reader.GetInt32(totalCustomersOrdinal)
            ));
        }

        return customersByCity;
    }

    public async Task<IEnumerable<LoyaltyLevelSummaryReportDto>> GetLoyaltySummaryReportAsync()
    {
        var loyaltySummaries = new List<LoyaltyLevelSummaryReportDto>();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetLoyaltySummaryReport]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var loyaltyLevelOrdinal = reader.GetOrdinal("LoyaltyLevel");
        var totalCustomersOrdinal = reader.GetOrdinal("Customers");
        var totalLoyaltyPointsOrdinal = reader.GetOrdinal("Total Points");

        while (await reader.ReadAsync())
        {
            loyaltySummaries.Add(new LoyaltyLevelSummaryReportDto(
                reader.GetString(loyaltyLevelOrdinal),
                reader.GetInt32(totalCustomersOrdinal),
                reader.GetInt32(totalLoyaltyPointsOrdinal)
            ));
        }

        return loyaltySummaries;
    }

    public async Task<IEnumerable<CustomerRegistrationSummaryDto>> GetRegistrationSummaryAsync()
    {
        var registrationSummaries = new List<CustomerRegistrationSummaryDto>();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetRegistrationSummary]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var yearOrdinal = reader.GetOrdinal("Year");
        var newCustomersOrdinal = reader.GetOrdinal("New Customers");

        while (await reader.ReadAsync())
        {
            registrationSummaries.Add(new CustomerRegistrationSummaryDto(
                reader.GetInt32(yearOrdinal),
                reader.GetInt32(newCustomersOrdinal)
            ));
        }

        return registrationSummaries;
    }
}