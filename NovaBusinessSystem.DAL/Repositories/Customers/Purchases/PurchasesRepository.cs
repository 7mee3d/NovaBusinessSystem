using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.DAL.Repositories;

public class PurchasesRepository : IPurchasesRepository
{
    public async Task<IEnumerable<CustomerPurchaseDto>> GetPurchaseHistoryAsync(int customerId)
    {
        List<CustomerPurchaseDto> purchaseHistory = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetPurchaseHistory]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerId;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var saleIdOrdinal = reader.GetOrdinal("SaleID");
        var saleDateOrdinal = reader.GetOrdinal("Date");
        var totalAmountOrdinal = reader.GetOrdinal("Amount");
        var paymentMethodOrdinal = reader.GetOrdinal("PaymentMethod");
        var statusOrdinal = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            purchaseHistory.Add(new CustomerPurchaseDto(
                reader.GetInt32(saleIdOrdinal),
                DateTime.Parse(reader.GetString(saleDateOrdinal)),
                reader.GetDecimal(totalAmountOrdinal),
                reader.GetString(paymentMethodOrdinal),
                reader.GetString(statusOrdinal)
            ));
        }

        return purchaseHistory;
    }

    public async Task<CustomerSpendingSummaryDto?> GetCustomerSpendingAsync(int customerId)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomerSpending]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerId;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        var totalOrdersOrdinal = reader.GetOrdinal("TotalOrders");
        var completedOrdersOrdinal = reader.GetOrdinal("Completed");
        var pendingOrdersOrdinal = reader.GetOrdinal("Pending");
        var cancelledOrdersOrdinal = reader.GetOrdinal("Cancelled");
        var totalSpentOrdinal = reader.GetOrdinal("TotalSpent");
        var averageOrderValueOrdinal = reader.GetOrdinal("AverageOrder");
        var largestOrderValueOrdinal = reader.GetOrdinal("LargestOrder");
        var firstPurchaseDateOrdinal = reader.GetOrdinal("FirstPurchase");
        var lastPurchaseDateOrdinal = reader.GetOrdinal("LastPurchase");

        return new CustomerSpendingSummaryDto(
                reader.GetInt32(totalOrdersOrdinal),
                reader.GetInt32(completedOrdersOrdinal),
                reader.GetInt32(pendingOrdersOrdinal),
                reader.GetInt32(cancelledOrdersOrdinal),
                reader.GetDecimal(totalSpentOrdinal),
                reader.GetDecimal(averageOrderValueOrdinal),
                reader.GetDecimal(largestOrderValueOrdinal),
                reader.IsDBNull(firstPurchaseDateOrdinal)
                    ? null
                    : reader.GetDateTime(firstPurchaseDateOrdinal),
                reader.IsDBNull(lastPurchaseDateOrdinal)
                    ? null
                    : reader.GetDateTime(lastPurchaseDateOrdinal)
);
    }

    public async Task<IEnumerable<FavoriteProductDto>> GetCustomerFavoriteProductsAsync(int customerId)
    {
        List<FavoriteProductDto> favoriteProducts = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomerFavoriteProducts]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerId;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var rankOrdinal = reader.GetOrdinal("Rank");
        var productNameOrdinal = reader.GetOrdinal("ProductName");
        var totalQuantityPurchasedOrdinal = reader.GetOrdinal("Quantity");

        while (await reader.ReadAsync())
        {
            favoriteProducts.Add(new FavoriteProductDto(
                reader.GetInt64(rankOrdinal),
                reader.GetString(productNameOrdinal),
                reader.GetInt32(totalQuantityPurchasedOrdinal)
            ));
        }

        return favoriteProducts;
    }

    public async Task<IEnumerable<MonthlyPurchaseSummaryDto>> GetCustomerMonthlyPurchasesAsync()
    {
        List<MonthlyPurchaseSummaryDto> monthlyPurchaseSummaries = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomerMonthlyPurchases]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var monthOrdinal = reader.GetOrdinal("Month");
        var totalOrdersOrdinal = reader.GetOrdinal("Orders");
        var totalSpentOrdinal = reader.GetOrdinal("TotalSpent");

        while (await reader.ReadAsync())
        {
            monthlyPurchaseSummaries.Add(new MonthlyPurchaseSummaryDto(
                reader.GetString(monthOrdinal),
                reader.GetInt32(totalOrdersOrdinal),
                reader.GetDecimal(totalSpentOrdinal)
            ));
        }

        return monthlyPurchaseSummaries;
    }

    public async Task<IEnumerable<CustomerRankingDto>> GetCustomersRankingAsync()
    {
        List<CustomerRankingDto> customerRankings = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomersRanking]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var rankOrdinal = reader.GetOrdinal("Rank");
        var customerNameOrdinal = reader.GetOrdinal("FullName");
        var totalOrdersOrdinal = reader.GetOrdinal("Orders");
        var totalSpentOrdinal = reader.GetOrdinal("Spending");

        while (await reader.ReadAsync())
        {
            customerRankings.Add(new CustomerRankingDto(
                reader.GetInt64(rankOrdinal),
                reader.GetString(customerNameOrdinal),
                reader.GetInt32(totalOrdersOrdinal),
                reader.GetDecimal(totalSpentOrdinal)
            ));
        }

        return customerRankings;
    }

}