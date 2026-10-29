using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.DAL.Products.Reports
{
    public class ProductsReportsRepository : IProductsReportsRepository
    {
        public async Task<IEnumerable<ProductStatusSummaryReportDto>> GetProductStatusSummariesAsync()
        {
            List<ProductStatusSummaryReportDto> Summaries = new();

            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using var command = new SqlCommand("[dbo].[usp_GetStatusSummary]", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            var status = reader.GetOrdinal("Status");
            var products = reader.GetOrdinal("Products");
            while (await reader.ReadAsync())
            {
                Summaries.Add(new ProductStatusSummaryReportDto(
                    reader.GetString(status),
                    reader.GetInt32(products)
                ));
            }


            return Summaries;
        }

        public async Task<IEnumerable<ProductsByCategoryReportDto>> GetProductByCategoriesAsync()
        {
            List<ProductsByCategoryReportDto> productsByCategories = new();

            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using var command = new SqlCommand("[dbo].[usp_GetProductsByCategory]", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };


            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();


            var category = reader.GetOrdinal("Category");
            var products = reader.GetOrdinal("Products");

            while (await reader.ReadAsync())
            {
                productsByCategories.Add(new ProductsByCategoryReportDto(
                    reader.GetString(category),
                    reader.GetInt32(products)
                ));
            }

            return productsByCategories;

        }

        public async Task<IEnumerable<StockLevelReportDto>> GetStockLevelReportsAsync()
        {
            List<StockLevelReportDto> stockLevelReports = new();


            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using var command = new SqlCommand("[dbo].[usp_GetStockLevelReport]", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };


            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            var productName = reader.GetOrdinal("ProductName");
            var stockQuantity = reader.GetOrdinal("StockQuantity");
            var stockLevel = reader.GetOrdinal("StockLevel");

            while (await reader.ReadAsync())
            {
                stockLevelReports.Add(new StockLevelReportDto(
                    reader.GetString(productName),
                    reader.GetInt32(stockQuantity),
                    reader.GetString(stockLevel)
                ));
            }


            return stockLevelReports;
        }

        public async Task<IEnumerable<InventoryValuationReportDto>> GetInventoryValuationsAsync()
        {
            List<InventoryValuationReportDto> inventoryValuations = new();

            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using var command = new SqlCommand("[dbo].[usp_GetInventoryValuation]", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            var category = reader.GetOrdinal("Category");
            var products = reader.GetOrdinal("Products");
            var units = reader.GetOrdinal("Units");
            var inventoryValue = reader.GetOrdinal("InventoryValue");

            while (await reader.ReadAsync())
            {
                inventoryValuations.Add(new InventoryValuationReportDto(
                    reader.GetString(category),
                    reader.GetInt32(products),
                    reader.GetInt32(units),
                    reader.GetDecimal(inventoryValue)
                ));
            }


            return inventoryValuations;
        }

        public async Task<IEnumerable<SalesPerformanceReportDto>> GetSalesPerformanceReportsAsync()
        {
            List<SalesPerformanceReportDto> salesPerformanceReports = new();

            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using var command = new SqlCommand("[dbo].[usp_GetSalesPerformanceReport]", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };


            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();
            var productName = reader.GetOrdinal("ProductName");
            var orders = reader.GetOrdinal("Orders");
            var units = reader.GetOrdinal("Units");
            var revenue = reader.GetOrdinal("Revenue");
            var performance = reader.GetOrdinal("Performance");

            while (await reader.ReadAsync())
            {
                salesPerformanceReports.Add(new SalesPerformanceReportDto(
                    reader.GetString(productName),
                    reader.GetInt32(orders),
                    reader.GetInt32(units),
                    reader.GetDecimal(revenue),
                    reader.GetString(performance)
                ));
            }

            return salesPerformanceReports;
        }

        public async Task<IEnumerable<CategoryRevenueReportDto>> GetCategoryRevenueReportsAsync()
        {
            List<CategoryRevenueReportDto> categoryRevenueReports = new();

            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using var command = new SqlCommand("[dbo].[usp_GetCategoryRevenueReport]", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            var rank = reader.GetOrdinal("Rank");
            var category = reader.GetOrdinal("Category");
            var orders = reader.GetOrdinal("Orders");
            var units = reader.GetOrdinal("Units");
            var revenue = reader.GetOrdinal("Revenue");

            while (await reader.ReadAsync())
            {
                categoryRevenueReports.Add(new CategoryRevenueReportDto(
                    reader.GetInt64(rank),
                    reader.GetString(category),
                    reader.GetInt32(orders),
                    reader.GetInt32(units),
                    reader.GetDecimal(revenue)
                ));
            }

            return categoryRevenueReports;
        }

        public async Task<IEnumerable<TopSellingProductReportDto>> GetTopSellingProductsAsync(int rank)
        {
            List<TopSellingProductReportDto> topSellingProducts = new();

            using SqlConnection connection = new SqlConnection(
                HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command = new SqlCommand(
                "[dbo].[usp_GetTopSellingProducts]", connection)
            {

                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("@Rank", SqlDbType.Int).Value = rank;

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            var productRank = reader.GetOrdinal("Rank");
            var productName = reader.GetOrdinal("ProductName");
            var category = reader.GetOrdinal("Category");
            var units = reader.GetOrdinal("Units");

            while (await reader.ReadAsync())
            {
                topSellingProducts.Add(new TopSellingProductReportDto(
                    reader.GetInt64(productRank),
                    reader.GetString(productName),
                    reader.GetString(category),
                    reader.GetInt32(units)
                ));
            }

            return topSellingProducts;
        }


        public async Task<IEnumerable<SlowMovingProductReportDto>> GetSlowMovingProductsAsync(
            int maximumUnitsSold)
        {
            List<SlowMovingProductReportDto> slowMovingProducts = new();

            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using var command = new SqlCommand("[dbo].[usp_GetSlowMovingProducts]", connection)
            {

                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("@MaximumUnitsSold", SqlDbType.Int).Value = maximumUnitsSold;

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            var productName = reader.GetOrdinal("ProductName");
            var category = reader.GetOrdinal("Category");
            var unitsSold = reader.GetOrdinal("UnitsSold");

            while (await reader.ReadAsync())
            {
                slowMovingProducts.Add(new SlowMovingProductReportDto(
                    reader.GetString(productName),
                    reader.GetString(category),
                    reader.GetInt32(unitsSold)
                ));
            }

            return slowMovingProducts;
        }

        public async Task<IEnumerable<UnsoldProductReportDto>> GetUnsoldProductsAsync()
        {
            List<UnsoldProductReportDto> unsoldProducts = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command = new SqlCommand("[dbo].[usp_GetUnsoldProducts]", connection)
            {

                CommandType = CommandType.StoredProcedure
            };

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            var productID = reader.GetOrdinal("ProductID");
            var productName = reader.GetOrdinal("ProductName");
            var category = reader.GetOrdinal("Category");
            var stockQuantity = reader.GetOrdinal("StockQuantity");

            while (await reader.ReadAsync())
            {
                unsoldProducts.Add(new UnsoldProductReportDto(
                    reader.GetInt32(productID),
                    reader.GetString(productName),
                    reader.GetString(category),
                    reader.GetInt32(stockQuantity)
                ));
            }

            return unsoldProducts;
        }

        public async Task<IEnumerable<MonthlyProductPerformanceReportDto>> GetMonthlyProductPerformanceAsync()
        {
            List<MonthlyProductPerformanceReportDto> monthlyProductPerformance = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command = new SqlCommand("[dbo].[usp_GetMonthlyProductPerformance]", connection)
            {

                CommandType = CommandType.StoredProcedure
            };

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            var month = reader.GetOrdinal("Month");
            var orders = reader.GetOrdinal("Orders");
            var units = reader.GetOrdinal("Units");
            var revenue = reader.GetOrdinal("Revenue");
            var growth = reader.GetOrdinal("Growth");

            while (await reader.ReadAsync())
            {
                monthlyProductPerformance.Add(
                    new MonthlyProductPerformanceReportDto(
                        reader.GetString(month),
                        reader.GetInt32(orders),
                        reader.GetInt32(units),
                        reader.GetDecimal(revenue),
                        reader.GetString(growth)
                    ));
            }

            return monthlyProductPerformance;
        }
    }
}