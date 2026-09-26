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

        public static async Task<CustomerSpendingSummaryDTO>? GetCustomerSpending(int customerId)
        {

            CustomerSpendingSummaryDTO customerSpendingSummary = null!;

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetCustomerSpending", connection))
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int).Value = customerId;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {

                            customerSpendingSummary = new CustomerSpendingSummaryDTO(

                                    reader.GetInt32(reader.GetOrdinal("TotalOrders")),
                                    reader.GetInt32(reader.GetOrdinal("Completed")),
                                    reader.GetInt32(reader.GetOrdinal("Pending")),
                                    reader.GetInt32(reader.GetOrdinal("Cancelled")),
                                    reader.GetString(reader.GetOrdinal("TotalSpent")),
                                    reader.GetString(reader.GetOrdinal("AverageOrder")),
                                    reader.GetString(reader.GetOrdinal("LargestOrder")),
                                    reader.GetString(reader.GetOrdinal("FirstPurchase")),
                                    reader.GetString(reader.GetOrdinal("LastPurchase"))
                             );

                        }
                    }

                }
                catch (SqlException ex)
                {
                    throw;
                }
            }

            return customerSpendingSummary!;
        }
    }
}