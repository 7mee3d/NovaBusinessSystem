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

        public static async Task<IEnumerable<CustomersByCityDTO>>? GetCustomersByCityAsync()
        {

            List<CustomersByCityDTO> L_CustomersByCities = new();


            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_GetCustomersByCity", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            L_CustomersByCities.Add(
                             new CustomersByCityDTO(

                                    reader.GetString(reader.GetOrdinal("City")),
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

            return L_CustomersByCities!;
        }

        public static async Task<IEnumerable<LoyaltySummaryDTO>>? GetLoyaltySummaryReportAsync()
        {

            List<LoyaltySummaryDTO> L_LoyaltySummaries = new();


            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_GetLoyaltySummaryReport", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            L_LoyaltySummaries.Add(

                             new LoyaltySummaryDTO(

                                    reader.GetString(reader.GetOrdinal("LoyaltyLevel")),
                                    reader.GetInt32(reader.GetOrdinal("Customers")),
                                    reader.GetInt32(reader.GetOrdinal("Total Points"))


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

            return L_LoyaltySummaries!;
        }

    }
}