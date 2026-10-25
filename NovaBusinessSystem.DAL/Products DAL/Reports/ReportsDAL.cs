
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
    }
}