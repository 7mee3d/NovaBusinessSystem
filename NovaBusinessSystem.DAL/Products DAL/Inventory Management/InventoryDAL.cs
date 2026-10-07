

using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Products.Inventory;

namespace NovaBusinessSystem.DAL.Products.Inventory
{
    public class InventoryDAL
    {

        public static async Task<ProductStockDTO?> ViewProductStockAsync(int productID)
        {
            ProductStockDTO? productStock = null;

            using (SqlConnection connection =
                new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                new SqlCommand("[dbo].[usp_ViewProductStock]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(
                    "@ProductID",
                    SqlDbType.Int
                ).Value = productID;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader =
                        await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            productStock = new ProductStockDTO(
                                reader.GetInt32(
                                    reader.GetOrdinal("ProductID")),

                                reader.GetString(
                                    reader.GetOrdinal("ProductName")),

                                reader.GetString(
                                    reader.GetOrdinal("Category")),

                                reader.GetDecimal(
                                    reader.GetOrdinal("Price")),

                                reader.GetInt32(
                                    reader.GetOrdinal("StockQuantity")),

                                reader.GetDecimal(
                                    reader.GetOrdinal("Stock Value")),

                                reader.GetString(
                                    reader.GetOrdinal("Status"))
                            );
                        }
                    }

                    return productStock;
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public static async Task<AddStockResultDTO?> AddStockAsync(int productID, int stockToAdded)
        {

            using SqlConnection connection =
                new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command =
                new SqlCommand("[dbo].[usp_AddStock]", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@ProductID",
                SqlDbType.Int
            ).Value = productID;

            command.Parameters.Add(
                "@StockToAdded",
                SqlDbType.Int
            ).Value = stockToAdded;


            await connection.OpenAsync();

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new AddStockResultDTO(
                    reader.GetInt32(reader.GetOrdinal("ProductID")),
                    reader.GetString(reader.GetOrdinal("ProductName")),
                    reader.GetInt32(reader.GetOrdinal("PreviousStock")),
                    reader.GetInt32(reader.GetOrdinal("AddedStock")),
                    reader.GetInt32(reader.GetOrdinal("NewStock"))
                );
            }

            return null;
        }

        public static async Task<RemoveStockResultDTO?> RemoveStockAsync(
                int productID,
                int stockToBeRemove)
        {
            using SqlConnection connection =
                new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command =
                new SqlCommand("[dbo].[usp_RemoveStock]", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@ProductID",
                SqlDbType.Int
            ).Value = productID;

            command.Parameters.Add(
                "@StockToBeRemove",
                SqlDbType.Int
            ).Value = stockToBeRemove;

            await connection.OpenAsync();

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new RemoveStockResultDTO(
                    reader.GetInt32(
                        reader.GetOrdinal("ProductID")),

                    reader.GetString(
                        reader.GetOrdinal("ProductName")),

                    reader.GetInt32(
                        reader.GetOrdinal("PreviousStock")),

                    reader.GetInt32(
                        reader.GetOrdinal("RemovedStock")),

                    reader.GetInt32(
                        reader.GetOrdinal("NewStock"))
                );
            }

            return null;
        }

        public static async Task<AdjustStockResultDTO?> AdjustStockAsync(
                    int productID,
                    int actualStock)
        {
            using SqlConnection connection =
                new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command =
                new SqlCommand("[dbo].[usp_AdjustStock]", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
            command.Parameters.Add("@ActualStock", SqlDbType.Int).Value = actualStock;

            await connection.OpenAsync();

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new AdjustStockResultDTO(
                    reader.GetInt32(reader.GetOrdinal("ProductID")),
                    reader.GetString(reader.GetOrdinal("ProductName")),
                    reader.GetInt32(reader.GetOrdinal("PreviousStock")),
                    reader.GetInt32(reader.GetOrdinal("ActualStock")),
                    reader.GetInt32(reader.GetOrdinal("Adjustment"))
                );
            }

            return null;
        }
    }
}