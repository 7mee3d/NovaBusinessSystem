
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


            return inventoryValuations ;
        }
    }
}