using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.DAL.Products
{

    public class ProductsDAL
    {

        public async static Task<IEnumerable<ProductDTO>>? GetAllProductsAsync()
        {
            List<ProductDTO> L_Products = new List<ProductDTO>();


            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetAllProducts", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                        {
                            L_Products.Add(

                                 new ProductDTO(
                                     reader.GetInt32(reader.GetOrdinal("ProductID")),
                                     reader.GetString(reader.GetOrdinal("ProductName")),
                                     reader.GetString(reader.GetOrdinal("Category")),
                                     reader.GetDecimal(reader.GetOrdinal("Price")),
                                     reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                     reader.GetString(reader.GetOrdinal("Status"))
                                 )

                            );
                        }


                }

                catch (SqlException) { throw; }
                ;
            }

            return L_Products;

        }

        public async static Task<ProductDTO>? GetProductByIDAsync(int productID)
        {
            ProductDTO productInformation = null!;


            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].[usp_GetProductByID]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;


                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                        {

                            productInformation = new ProductDTO(
                                 reader.GetInt32(reader.GetOrdinal("ProductID")),
                                 reader.GetString(reader.GetOrdinal("ProductName")),
                                 reader.GetString(reader.GetOrdinal("Category")),
                                 reader.GetDecimal(reader.GetOrdinal("Price")),
                                 reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                 reader.GetString(reader.GetOrdinal("Status"))
                             );

                        }


                }

                catch (SqlException) { throw; }
                ;
            }

            return productInformation!;

        }

        public async static Task<int>? AddNewProductAsync(ProductDTO product)
        {

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].[usp_AddNewProduct]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;
                command.Parameters.Add("@Category", SqlDbType.VarChar, 100).Value = product.Category;

                SqlParameter priceParameter =
                    command.Parameters.Add("@Price", SqlDbType.Decimal);

                priceParameter.Precision = 18;
                priceParameter.Scale = 2;
                priceParameter.Value = product.Price;

                command.Parameters.Add("@StockQuantity", SqlDbType.Int).Value = product.StockQuantity;
                command.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = product.Status;

                SqlParameter paramProductID = new SqlParameter("@ProductID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(paramProductID);



                try
                {
                    await connection.OpenAsync();

                    await command.ExecuteNonQueryAsync();

                    return Convert.ToInt32(paramProductID.Value);

                }

                catch (SqlException) { throw; }
                ;
            }
        }

        public async static Task<int>? UpdateProductAsync(int productID, ProductUpdateDTO product)
        {

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].[usp_UpdateProduct]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;
                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                command.Parameters.Add("@Category", SqlDbType.VarChar, 100).Value = product.Category;

                SqlParameter priceParameter =
                    command.Parameters.Add("@Price", SqlDbType.Decimal);

                priceParameter.Precision = 18;
                priceParameter.Scale = 2;
                priceParameter.Value = product.Price;

                command.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = product.Status;





                try
                {
                    await connection.OpenAsync();
                    return Convert.ToInt32(await command.ExecuteScalarAsync());

                }

                catch (SqlException) { throw; }
                ;
            }
        }

        public async static Task<bool>? DeleteProductAsync(int productID)
        {

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].[usp_DeleteProduct]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    return true;

                }

                catch (SqlException) { throw; }
                ;
            }
        }
    }

}