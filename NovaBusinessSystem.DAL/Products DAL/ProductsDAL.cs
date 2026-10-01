using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.DAL.Products
{

    public class ProductsDAL
    {

        public async static Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
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
    }

}