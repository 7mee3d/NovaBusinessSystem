using System.Reflection.Metadata.Ecma335;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.DAL.Products.Sales
{

    public class SalesDAL
    {


        public static async Task<IEnumerable<ProductSalesHistoryDTO>> GetProductSalesHistoriesAsync(int productID)
        {

            List<ProductSalesHistoryDTO> L_ProductSalesHistories = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[usp_GetProductSalesHistory]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = productID;

            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        L_ProductSalesHistories.Add(

                            new ProductSalesHistoryDTO(

                            reader.GetInt32(reader.GetOrdinal("SaleID")),
                            reader.GetString(reader.GetOrdinal("Date")),
                            reader.GetString(reader.GetOrdinal("Customer")),
                            reader.GetInt32(reader.GetOrdinal("Quantity")),
                            reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                            reader.GetString(reader.GetOrdinal("Status"))

                            )

                        );
                    }

            }
            catch (SqlException)
            {

                throw;

            }

            return L_ProductSalesHistories;

        }

        public static async Task<IEnumerable<ProductSalesSummaryDTO>> GetProductSalesSummariesAsync(int productID)
        {
            List<ProductSalesSummaryDTO> L_ProductSalesSummaries = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[usp_GetProductSalesSummary]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = productID;

            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        L_ProductSalesSummaries.Add(
                                new ProductSalesSummaryDTO(
                                reader.GetInt32(reader.GetOrdinal("ProductID")),
                                reader.GetString(reader.GetOrdinal("ProductName")),
                                reader.GetString(reader.GetOrdinal("Category")),
                                reader.GetInt32(reader.GetOrdinal("Orders")),
                                reader.GetInt32(reader.GetOrdinal("UnitsSold")),
                                reader.GetDecimal(reader.GetOrdinal("Revenue")),
                                reader.GetDecimal(reader.GetOrdinal("AverageQty")),
                                reader.GetDecimal(reader.GetOrdinal("AverageRevenue"))
                                )
                        );
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return L_ProductSalesSummaries;
        }


        public static async Task<IEnumerable<TopSellingProductDTO>> GetTopSellingProductsAsync(int rank)
        {
            List<TopSellingProductDTO> L_TopSellingProducts = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[usp_GetTopSellingProducts]", connection);


            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@Rank", System.Data.SqlDbType.Int).Value = rank;

            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        L_TopSellingProducts.Add(
                            new TopSellingProductDTO(
                                reader.GetInt64(reader.GetOrdinal("Rank")),
                                reader.GetString(reader.GetOrdinal("ProductName")),
                                reader.GetInt32(reader.GetOrdinal("UnitsSold")),
                                reader.GetInt32(reader.GetOrdinal("Orders"))
                            )
                        );
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return L_TopSellingProducts;
        }

    }
}