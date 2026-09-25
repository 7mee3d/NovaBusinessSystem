using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.DAL
{
    public class LoyaltyDAL
    {
        public static async Task<CustomerPointsDTO>? ViewCustomerPoints(int id)
        {
            CustomerPointsDTO? customerPointsDTO = null;

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_ViewCustomerPoints", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = id;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            customerPointsDTO = new CustomerPointsDTO(

                                 reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                 reader.GetString(reader.GetOrdinal("FullName")),
                                 reader.GetInt32(reader.GetOrdinal("Current Points")),
                                 reader.GetString(reader.GetOrdinal("Loyalty Level"))

                             );


                        }
                    }

                }
                catch (SqlException)
                {
                    return null;
                }
            }

            return customerPointsDTO;
        }

        public static async Task<bool>? AddPointsToCustomer(int id, int pointsToAdd)
        {

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_AddPoints", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = id;
                command.Parameters.Add("@PointsToAdd", SqlDbType.Int).Value = pointsToAdd;

                try
                {
                    connection.Open();

                    return Convert.ToInt32(await command.ExecuteScalarAsync()) > 0;

                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static async Task<bool>? RedeemPointsToCustomer(int id, int pointsToRedeem)
        {

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_RedeemPoints", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = id;
                command.Parameters.Add("@PointToRedeem", SqlDbType.Int).Value = pointsToRedeem;

                try
                {
                    connection.Open();

                    return Convert.ToInt32(await command.ExecuteScalarAsync()) > 0;

                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static async Task<IEnumerable<TopLoyaltyCustomerDTO>>? GetTopLoyaltyCustomers()
        {

            List<TopLoyaltyCustomerDTO>? L_TopLoyaltyCustomerDTO = new();

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_GetTopLoyaltyCustomers", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            L_TopLoyaltyCustomerDTO.Add(

                                new TopLoyaltyCustomerDTO(

                                 reader.GetInt64(reader.GetOrdinal("Rank")),
                                 reader.GetString(reader.GetOrdinal("FullName")),
                                 reader.GetInt32(reader.GetOrdinal("Points")),
                                 reader.GetString(reader.GetOrdinal("Level"))

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

            return L_TopLoyaltyCustomerDTO;
        }

        public static async Task<LoyaltyStatisticsDTO>? GetLoyaltyStatistics()
        {

            LoyaltyStatisticsDTO LoyaltyStatisticsDTO = null;

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("[dbo].[usp_GetLoyaltyStatistics]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {

                            LoyaltyStatisticsDTO = new LoyaltyStatisticsDTO(

                              reader.GetInt32(reader.GetOrdinal("Total Loyalty Points")),
                              reader.GetInt32(reader.GetOrdinal("Minimum Points")),
                              reader.GetInt32(reader.GetOrdinal("Maximum Points")),
                              reader.GetDecimal(reader.GetOrdinal("Average Points")),
                              reader.GetInt32(reader.GetOrdinal("Diamond Customers")),
                              reader.GetInt32(reader.GetOrdinal("Platinum Customers")),
                              reader.GetInt32(reader.GetOrdinal("Gold Customers")),
                              reader.GetInt32(reader.GetOrdinal("Silver Customers")),
                              reader.GetInt32(reader.GetOrdinal("Bronze Customers"))


                             );
                        }
                    }

                }
                catch (SqlException)
                {
                    return null!;
                }
            }

            return LoyaltyStatisticsDTO!;
        }
    }
}