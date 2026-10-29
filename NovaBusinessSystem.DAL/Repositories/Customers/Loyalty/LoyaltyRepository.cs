using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers.Loyalty;


namespace NovaBusinessSystem.DAL.Repositories;

public class LoyaltyRepository : ILoyaltyRepository
{
    public async Task<CustomerPointsDto?> GetCustomerPointsAsync(int customerID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_ViewCustomerPoints]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        var customerIDOrdinal = reader.GetOrdinal("CustomerID");
        var fullNameOrdinal = reader.GetOrdinal("FullName");
        var currentPointsOrdinal = reader.GetOrdinal("Current Points");
        var loyaltyLevelOrdinal = reader.GetOrdinal("Loyalty Level");

        return new CustomerPointsDto(
            reader.GetInt32(customerIDOrdinal),
            reader.GetString(fullNameOrdinal),
            reader.GetInt32(currentPointsOrdinal),
            reader.GetString(loyaltyLevelOrdinal)
        );
    }

    public async Task<bool> AddPointsAsync(int customerID, int pointsToAdd)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_AddPoints]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
        command.Parameters.Add("@PointsToAdd", SqlDbType.Int).Value = pointsToAdd;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

    public async Task<bool> RedeemPointsAsync(int customerID, int pointsToRedeem)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_RedeemPoints]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
        command.Parameters.Add("@PointToRedeem", SqlDbType.Int).Value = pointsToRedeem;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

    public async Task<IEnumerable<TopLoyaltyCustomerDto>> GetTopLoyaltyCustomersAsync()
    {
        List<TopLoyaltyCustomerDto> topLoyaltyCustomers = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetTopLoyaltyCustomers]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var rankOrdinal = reader.GetOrdinal("Rank");
        var customerNameOrdinal = reader.GetOrdinal("FullName");
        var pointsOrdinal = reader.GetOrdinal("Points");
        var levelOrdinal = reader.GetOrdinal("Level");
        while (await reader.ReadAsync())
        {
            topLoyaltyCustomers.Add(new TopLoyaltyCustomerDto(
                reader.GetInt64(rankOrdinal),
                reader.GetString(customerNameOrdinal),
                reader.GetInt32(pointsOrdinal),
                reader.GetString(levelOrdinal)
            ));
        }

        return topLoyaltyCustomers;
    }

    public async Task<LoyaltyStatisticsDto?> GetLoyaltyStatisticsAsync()
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetLoyaltyStatistics]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        var totalPointsOrdinal = reader.GetOrdinal("Total Loyalty Points");
        var minimumPointsOrdinal = reader.GetOrdinal("Minimum Points");
        var maximumPointsOrdinal = reader.GetOrdinal("Maximum Points");
        var averagePointsOrdinal = reader.GetOrdinal("Average Points");
        var diamondCustomersOrdinal = reader.GetOrdinal("Diamond Customers");
        var platinumCustomersOrdinal = reader.GetOrdinal("Platinum Customers");
        var goldCustomersOrdinal = reader.GetOrdinal("Gold Customers");
        var silverCustomersOrdinal = reader.GetOrdinal("Silver Customers");
        var bronzeCustomersOrdinal = reader.GetOrdinal("Bronze Customers");

        return new LoyaltyStatisticsDto(
            reader.GetInt32(totalPointsOrdinal),
            reader.GetInt32(minimumPointsOrdinal),
            reader.GetInt32(maximumPointsOrdinal),
            reader.GetDecimal(averagePointsOrdinal),
            reader.GetInt32(diamondCustomersOrdinal),
            reader.GetInt32(platinumCustomersOrdinal),
            reader.GetInt32(goldCustomersOrdinal),
            reader.GetInt32(silverCustomersOrdinal),
            reader.GetInt32(bronzeCustomersOrdinal)
        );
    }
}