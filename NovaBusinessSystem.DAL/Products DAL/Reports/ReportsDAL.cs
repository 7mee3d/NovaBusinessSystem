
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.DAL.Products.Reports
{
    public class ReportsDAL : IReportsDAL
    {
        public async Task<IEnumerable<ProductStatusSummaryDTO>> GetProductStatusSummariesAsync()
        {
            List<ProductStatusSummaryDTO> Summaries = new();

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
                Summaries.Add(new ProductStatusSummaryDTO(
                    reader.GetString(status),
                    reader.GetInt32(products)
                ));
            }


            return Summaries;
        }

        public async Task<IEnumerable<ProductsByCategoryDTO>> GetProductByCategoriesAsync()
        {
            List<ProductsByCategoryDTO> productsByCategories = new();

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
                productsByCategories.Add(new ProductsByCategoryDTO(
                    reader.GetString(category),
                    reader.GetInt32(products)
                ));
            }

            return productsByCategories;

        }

        public async Task<IEnumerable<StockLevelReportDTO>> GetStockLevelReportsAsync()
        {
            List<StockLevelReportDTO> stockLevelReports = new();


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
                stockLevelReports.Add(new StockLevelReportDTO(
                    reader.GetString(productName),
                    reader.GetInt32(stockQuantity),
                    reader.GetString(stockLevel)
                ));
            }


            return stockLevelReports;
        }

        public async Task<IEnumerable<InventoryValuationDTO>> GetInventoryValuationsAsync()
        {
            List<InventoryValuationDTO> inventoryValuations = new();

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
                inventoryValuations.Add(new InventoryValuationDTO(
                    reader.GetString(category),
                    reader.GetInt32(products),
                    reader.GetInt32(units),
                    reader.GetDecimal(inventoryValue)
                ));
            }


            return inventoryValuations;
        }

        public async Task<IEnumerable<SalesPerformanceReportDTO>> GetSalesPerformanceReportsAsync()
        {
            List<SalesPerformanceReportDTO> salesPerformanceReports = new();

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
                salesPerformanceReports.Add(new SalesPerformanceReportDTO(
                    reader.GetString(productName),
                    reader.GetInt32(orders),
                    reader.GetInt32(units),
                    reader.GetDecimal(revenue),
                    reader.GetString(performance)
                ));
            }

            return salesPerformanceReports;
        }

        public async Task<IEnumerable<CategoryRevenueReportDTO>> GetCategoryRevenueReportsAsync()
        {
            List<CategoryRevenueReportDTO> categoryRevenueReports = new();

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
                categoryRevenueReports.Add(new CategoryRevenueReportDTO(
                    reader.GetInt64(rank),
                    reader.GetString(category),
                    reader.GetInt32(orders),
                    reader.GetInt32(units),
                    reader.GetDecimal(revenue)
                ));
            }

            return categoryRevenueReports;
        }
        public async Task<IEnumerable<TopSellingProductDTO>> GetTopSellingProductsAsync(int rank)
        {
            List<TopSellingProductDTO> topSellingProducts = new List<TopSellingProductDTO>();

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
                topSellingProducts.Add(new TopSellingProductDTO(
                    reader.GetInt64(productRank),
                    reader.GetString(productName),
                    reader.GetString(category),
                    reader.GetInt32(units)
                ));
            }

            return topSellingProducts;
        }


        public async Task<IEnumerable<SlowMovingProductDTO>> GetSlowMovingProductsAsync(
            int maximumUnitsSold)
        {
            List<SlowMovingProductDTO> slowMovingProducts = new();

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
                slowMovingProducts.Add(new SlowMovingProductDTO(
                    reader.GetString(productName),
                    reader.GetString(category),
                    reader.GetInt32(unitsSold)
                ));
            }

            return slowMovingProducts;
        }

        public async Task<IEnumerable<UnsoldProductDTO>> GetUnsoldProductsAsync()
        {
            List<UnsoldProductDTO> unsoldProducts = new();

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
                unsoldProducts.Add(new UnsoldProductDTO(
                    reader.GetInt32(productID),
                    reader.GetString(productName),
                    reader.GetString(category),
                    reader.GetInt32(stockQuantity)
                ));
            }

            return unsoldProducts;
        }

        public async Task<IEnumerable<MonthlyProductPerformanceDTO>> GetMonthlyProductPerformanceAsync()
        {
            List<MonthlyProductPerformanceDTO> monthlyProductPerformance = new();

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
                    new MonthlyProductPerformanceDTO(
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