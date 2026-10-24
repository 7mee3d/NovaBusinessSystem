using System.ComponentModel.Design.Serialization;
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

        public static async Task<IEnumerable<LeastSellingProductDTO>> GetLeastSellingProductsAsync(int rank)
        {
            List<LeastSellingProductDTO> L_LeastSellingProducts = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[usp_GetLeastSellingProduct]", connection);


            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@Rank", System.Data.SqlDbType.Int).Value = rank;

            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        L_LeastSellingProducts.Add(
                            new LeastSellingProductDTO(
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

            return L_LeastSellingProducts;
        }

        public static async Task<IEnumerable<ProductRevenueRankingDTO>> GetProductRevenueRankingsAsync(int rank)
        {
            List<ProductRevenueRankingDTO> L_ProductRevenueRankings = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[usp_GetProductRevenueRanking]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@Rank", System.Data.SqlDbType.Int).Value = rank;
            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        L_ProductRevenueRankings.Add(

                            new ProductRevenueRankingDTO(

                                        reader.GetInt64(reader.GetOrdinal("Rank")),
                                        reader.GetString(reader.GetOrdinal("ProductName")),
                                        reader.GetInt32(reader.GetOrdinal("Units")),
                                        reader.GetDecimal(reader.GetOrdinal("RevenueFromCompletedSales"))
                            )
                        );
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return L_ProductRevenueRankings;
        }


        public static async Task<IEnumerable<MonthlyProductSalesDTO>> GetMonthlyProductSalesAsync(int productID)
        {
            List<MonthlyProductSalesDTO> monthlyProductSales = new();

            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using var command = new SqlCommand("[dbo].[usp_GetMonthlyProductSales]", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            command.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = productID;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            var month = reader.GetOrdinal("Month");
            var orders = reader.GetOrdinal("Orders");
            var units = reader.GetOrdinal("Units");
            var revenue = reader.GetOrdinal("Revenue");
            var previous = reader.GetOrdinal("Previous");
            var change = reader.GetOrdinal("Change");

            while (await reader.ReadAsync())
            {
                decimal? previousRevenue = reader.IsDBNull(previous)
                                    ? null
                                    : reader.GetDecimal(previous);

                monthlyProductSales.Add(new MonthlyProductSalesDTO(
                    reader.GetString(month),
                    reader.GetInt32(orders),
                    reader.GetInt32(units),
                    reader.GetDecimal(revenue),
                     previousRevenue,
                    reader.GetString(change)
                )
            );

            }

            return monthlyProductSales;
        }

        public static async Task<IEnumerable<CategoryPerformanceDTO>> GetCategoryPerformancesAsync()
        {
            List<CategoryPerformanceDTO> categoryPerformances = new();

            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using var command = new SqlCommand("[dbo].[usp_GetCategoryPerformance]", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            var category = reader.GetOrdinal("Category");
            var products = reader.GetOrdinal("Products");
            var unitsSold = reader.GetOrdinal("UnitsSold");
            var revenue = reader.GetOrdinal("Revenue");

            while (await reader.ReadAsync())
            {
                categoryPerformances.Add(new CategoryPerformanceDTO(

                    reader.GetString(category),
                    reader.GetInt32(products),
                    reader.GetInt32(unitsSold),
                    reader.GetDecimal(revenue)

                ));

            }

            return categoryPerformances;
        }

        public static async Task<ProductCustomerSalesDTO?> GetProductCustomerSalesAsync(int productID)
        {
            using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using var command = new SqlCommand("[dbo].[usp_GetProductCustomerAnalysis]", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            command.Parameters.Add("@ProductID" , System.Data.SqlDbType.Int).Value = productID;
            
            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            var productName = reader.GetOrdinal("ProductName");
            var uniqueCustomers = reader.GetOrdinal("UniqueCustomers");
            var totalOrders = reader.GetOrdinal("TotalOrders");
            var unitsSold = reader.GetOrdinal("UnitsSold");
            var topCustomer = reader.GetOrdinal("TopCustomer");
            var unitsPurchased = reader.GetOrdinal("UnitsPurchased");
            var amountSpent = reader.GetOrdinal("AmountSpent");

            return new ProductCustomerSalesDTO(
                                                 reader.GetString(productName),
                                                 reader.GetInt32(uniqueCustomers),
                                                 reader.GetInt32(totalOrders),
                                                 reader.GetInt32(unitsSold),
                                                 reader.GetString(topCustomer),
                                                 reader.GetInt32(unitsPurchased),
                                                 reader.GetDecimal(amountSpent)
                                             );

        }
    }
}