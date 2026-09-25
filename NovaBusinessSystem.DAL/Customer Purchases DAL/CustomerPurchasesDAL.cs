using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.DAL
{
    public class CustomerPurchasesDAL
    {

        public static async Task<IEnumerable<CustomerPurchaseDTO>> GetPurchaseHistory(int customerId)
        {

            List<CustomerPurchaseDTO> purchaseHistory = new();

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetPurchaseHistory", connection))
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int).Value = customerId;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            purchaseHistory.Add(

                                new CustomerPurchaseDTO(

                                    reader.GetInt32(reader.GetOrdinal("SaleID")),
                                    reader.GetString(reader.GetOrdinal("Date")),
                                    reader.GetDecimal(reader.GetOrdinal("Amount")),
                                    reader.GetString(reader.GetOrdinal("PaymentMethod")),
                                    reader.GetString(reader.GetOrdinal("Status"))
                                )
                            );

                        }
                    }

                }
                catch (SqlException ex)
                {
                    throw;
                }
            }

            return purchaseHistory;
        }
    }
}