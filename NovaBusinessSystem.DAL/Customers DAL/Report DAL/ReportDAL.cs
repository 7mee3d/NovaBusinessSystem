using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.DAL.Customers.Reports
{

    public class ReportDAL
    {
        public static async Task<IEnumerable<CustomerStatusDTO>>? GetCustomerStatusSummaryAsync()
        {

            List<CustomerStatusDTO> customerStatuses = new();


            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("usp_GetCustomerStatusSummary", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            customerStatuses.Add(
                             new CustomerStatusDTO(

                                    reader.GetString(reader.GetOrdinal("Status")),
                                    reader.GetInt32(reader.GetOrdinal("Customers"))


                             )
                            );
                        }
                    }

                }
                catch (SqlException)
                {
                    return null!;
                }
            }

            return customerStatuses!;
        }
    }
}