

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

        public static async Task<IEnumerable<LowStockProductDTO>> GetLowStockProducts(int threshold)
        {
            List<LowStockProductDTO> lowStockProducts = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[usp_GetLowStockProducts]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Threshold", SqlDbType.Int).Value = threshold;

            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lowStockProducts.Add(
                            new LowStockProductDTO(

                                reader.GetInt32(reader.GetOrdinal("ProductID")),
                                reader.GetString(reader.GetOrdinal("ProductName")),
                                reader.GetString(reader.GetOrdinal("Category")),
                                reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                reader.GetString(reader.GetOrdinal("Status"))

                            )
                        );
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return lowStockProducts;
        }

        public static async Task<IEnumerable<OutOfStockProductDTO>> GetOutOfStockProducts()
        {

            List<OutOfStockProductDTO> outOfStockProducts = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[GetOutOfStockProducts]", connection);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        outOfStockProducts.Add(
                            new OutOfStockProductDTO(

                        reader.GetInt32(reader.GetOrdinal("ProductID")),
                        reader.GetString(reader.GetOrdinal("ProductName")),
                        reader.GetString(reader.GetOrdinal("Category")),
                        reader.GetString(reader.GetOrdinal("Status"))

                            )
                        );
                    }
                }

            }
            catch (SqlException)
            {
                throw;
            }

            return outOfStockProducts;
        }


        public static async Task<InventoryValueDTO?>  ? GetInventoryValueAsync()
        {

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command = new SqlCommand("[dbo].[usp_GetInventoryValue]", connection);


            command.CommandType = CommandType.StoredProcedure;


            try
            {
                await connection.OpenAsync();


                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    if (await reader.ReadAsync())
                    {
                        return new InventoryValueDTO(
                            reader.GetInt32(reader.GetOrdinal("TotalProducts")),
                            Convert.ToInt32(reader["TotalStockUnits"]),
                            Convert.ToDecimal(reader["TotalInventoryValue"]),
                            Convert.ToDecimal(reader["AverageProductPrice"]),
                            Convert.ToDecimal(reader["AverageStock"]),
                            reader["ProductName"].ToString()!,
                            Convert.ToDecimal(reader["StockValue"])
                        );
                    }

            }
            catch (SqlException)
            {
                throw;
            }
            return null ; 
        }
    }
}