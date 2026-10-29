using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.DAL.Repositories;

public class SalesRepository : ISalesRepository
{
    public async Task<IEnumerable<ProductSalesHistoryDto>> GetProductSalesHistoriesAsync(int productID)
    {
        List<ProductSalesHistoryDto> productSalesHistories = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetProductSalesHistory]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int saleIDOrdinal = reader.GetOrdinal("SaleID");
        int saleDateOrdinal = reader.GetOrdinal("Date");
        int customerNameOrdinal = reader.GetOrdinal("Customer");
        int quantityOrdinal = reader.GetOrdinal("Quantity");
        int unitPriceOrdinal = reader.GetOrdinal("UnitPrice");
        int statusOrdinal = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            productSalesHistories.Add(new ProductSalesHistoryDto(
                reader.GetInt32(saleIDOrdinal),
                reader.GetString(saleDateOrdinal),
                reader.GetString(customerNameOrdinal),
                reader.GetInt32(quantityOrdinal),
                reader.GetDecimal(unitPriceOrdinal),
                reader.GetString(statusOrdinal)
            ));
        }

        return productSalesHistories;
    }

    public async Task<IEnumerable<ProductSalesSummaryDto>> GetProductSalesSummariesAsync(int productID)
    {
        List<ProductSalesSummaryDto> productSalesSummaries = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetProductSalesSummary]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int productIDOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int ordersOrdinal = reader.GetOrdinal("Orders");
        int unitsSoldOrdinal = reader.GetOrdinal("UnitsSold");
        int revenueOrdinal = reader.GetOrdinal("Revenue");
        int averageQuantityOrdinal = reader.GetOrdinal("AverageQty");
        int averageRevenueOrdinal = reader.GetOrdinal("AverageRevenue");

        while (await reader.ReadAsync())
        {
            productSalesSummaries.Add(new ProductSalesSummaryDto(
                reader.GetInt32(productIDOrdinal),
                reader.GetString(productNameOrdinal),
                reader.GetString(categoryOrdinal),
                reader.GetInt32(ordersOrdinal),
                reader.GetInt32(unitsSoldOrdinal),
                reader.GetDecimal(revenueOrdinal),
                reader.GetDecimal(averageQuantityOrdinal),
                reader.GetDecimal(averageRevenueOrdinal)
            ));
        }

        return productSalesSummaries;
    }

    public async Task<IEnumerable<TopSellingProductDto>> GetTopSellingProductsAsync(int rank)
    {
        List<TopSellingProductDto> topSellingProducts = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetTopSellingProducts]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@Rank", SqlDbType.Int).Value = rank;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        var rankOrdinal = reader.GetOrdinal("Rank");
        var productNameOrdinal = reader.GetOrdinal("ProductName");
        var unitsSoldOrdinal = reader.GetOrdinal("UnitsSold");
        var ordersOrdinal = reader.GetOrdinal("Orders");

        while (await reader.ReadAsync())
        {
            topSellingProducts.Add(new TopSellingProductDto(
                reader.GetInt64(rankOrdinal),
                reader.GetString(productNameOrdinal),
                reader.GetInt32(unitsSoldOrdinal),
                reader.GetInt32(ordersOrdinal)
            ));
        }

        return topSellingProducts;
    }

    public async Task<IEnumerable<LeastSellingProductDto>> GetLeastSellingProductsAsync(int rank)
    {
        List<LeastSellingProductDto> leastSellingProducts = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetLeastSellingProduct]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@Rank", SqlDbType.Int).Value = rank;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int rankOrdinal = reader.GetOrdinal("Rank");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int unitsSoldOrdinal = reader.GetOrdinal("UnitsSold");
        int ordersOrdinal = reader.GetOrdinal("Orders");

        while (await reader.ReadAsync())
        {
            leastSellingProducts.Add(new LeastSellingProductDto(
                reader.GetInt64(rankOrdinal),
                reader.GetString(productNameOrdinal),
                reader.GetInt32(unitsSoldOrdinal),
                reader.GetInt32(ordersOrdinal)
            ));
        }

        return leastSellingProducts;
    }

    public async Task<IEnumerable<ProductRevenueRankingDto>> GetProductRevenueRankingsAsync(int rank)
    {
        List<ProductRevenueRankingDto> productRevenueRankings = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetProductRevenueRanking]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@Rank", SqlDbType.Int).Value = rank;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int rankOrdinal = reader.GetOrdinal("Rank");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int unitsOrdinal = reader.GetOrdinal("Units");
        int revenueOrdinal = reader.GetOrdinal("RevenueFromCompletedSales");

        while (await reader.ReadAsync())
        {
            productRevenueRankings.Add(new ProductRevenueRankingDto(
                reader.GetInt64(rankOrdinal),
                reader.GetString(productNameOrdinal),
                reader.GetInt32(unitsOrdinal),
                reader.GetDecimal(revenueOrdinal)
            ));
        }

        return productRevenueRankings;
    }

    public async Task<IEnumerable<MonthlyProductSalesDto>> GetMonthlyProductSalesAsync(int productID)
    {
        List<MonthlyProductSalesDto> monthlyProductSales = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetMonthlyProductSales]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int monthOrdinal = reader.GetOrdinal("Month");
        int ordersOrdinal = reader.GetOrdinal("Orders");
        int unitsOrdinal = reader.GetOrdinal("Units");
        int revenueOrdinal = reader.GetOrdinal("Revenue");
        int previousOrdinal = reader.GetOrdinal("Previous");
        int changeOrdinal = reader.GetOrdinal("Change");

        while (await reader.ReadAsync())
        {
            decimal? previousRevenue = reader.IsDBNull(previousOrdinal)
                ? null
                : reader.GetDecimal(previousOrdinal);

            monthlyProductSales.Add(new MonthlyProductSalesDto(
                reader.GetString(monthOrdinal),
                reader.GetInt32(ordersOrdinal),
                reader.GetInt32(unitsOrdinal),
                reader.GetDecimal(revenueOrdinal),
                previousRevenue,
                reader.GetString(changeOrdinal)
            ));
        }

        return monthlyProductSales;
    }

    public async Task<IEnumerable<CategoryPerformanceDto>> GetCategoryPerformancesAsync()
    {
        List<CategoryPerformanceDto> categoryPerformances = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCategoryPerformance]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int categoryOrdinal = reader.GetOrdinal("Category");
        int productsOrdinal = reader.GetOrdinal("Products");
        int unitsSoldOrdinal = reader.GetOrdinal("UnitsSold");
        int revenueOrdinal = reader.GetOrdinal("Revenue");

        while (await reader.ReadAsync())
        {
            categoryPerformances.Add(new CategoryPerformanceDto(
                reader.GetString(categoryOrdinal),
                reader.GetInt32(productsOrdinal),
                reader.GetInt32(unitsSoldOrdinal),
                reader.GetDecimal(revenueOrdinal)
            ));
        }

        return categoryPerformances;
    }

    public async Task<ProductCustomerSalesDto?> GetProductCustomerSalesAsync(int productID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetProductCustomerAnalysis]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int uniqueCustomersOrdinal = reader.GetOrdinal("UniqueCustomers");
        int totalOrdersOrdinal = reader.GetOrdinal("TotalOrders");
        int unitsSoldOrdinal = reader.GetOrdinal("UnitsSold");
        int topCustomerOrdinal = reader.GetOrdinal("TopCustomer");
        int unitsPurchasedOrdinal = reader.GetOrdinal("UnitsPurchased");
        int amountSpentOrdinal = reader.GetOrdinal("AmountSpent");

        return new ProductCustomerSalesDto(
            reader.GetString(productNameOrdinal),
            reader.GetInt32(uniqueCustomersOrdinal),
            reader.GetInt32(totalOrdersOrdinal),
            reader.GetInt32(unitsSoldOrdinal),
            reader.GetString(topCustomerOrdinal),
            reader.GetInt32(unitsPurchasedOrdinal),
            reader.GetDecimal(amountSpentOrdinal)
        );
    }
}