using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;

namespace nCustomersDAL
{

    public class CustomersDAL
    {

        public static IEnumerable<CustomerDTO> GetAllCustomersList()
        {
            List<CustomerDTO> L_AllCustomers = new List<CustomerDTO>();


            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetCustomers", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            L_AllCustomers.Add(
                                new CustomerDTO(
                                    reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Phone")),
                                    reader.GetString(reader.GetOrdinal("City")),
                                    reader.GetDateTime(reader.GetOrdinal("RegistrationDate")),
                                    reader.GetInt32(reader.GetOrdinal("LoyaltyPoints")),
                                    reader.GetString(reader.GetOrdinal("Status"))

                                )

                            );
                        }


                }

                catch { throw; }
                ;
            }

            return L_AllCustomers;

        }
        public static CustomerDTO? FindCustomerBy(int CustomerID)
        {
            CustomerDTO? customerDTO = null;

            using (SqlConnection connection = new SqlConnection(
                HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command = new SqlCommand(
                "dbo.usp_GetCustomerByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parmID = command.Parameters.Add("@ID", SqlDbType.Int);
                parmID.Direction = ParameterDirection.Input;
                parmID.Value = CustomerID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerDTO = new CustomerDTO(
                            CustomerID,
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (string)reader["Email"],
                            (string)reader["Phone"],
                            (string)reader["City"],
                            (DateTime)reader["RegistrationDate"],
                            Convert.ToInt16(reader["LoyaltyPoints"]),
                            (string)reader["Status"]

                            );
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }

            return customerDTO;
        }


        public static int AddNewCustomer(CustomerAddDTO customerDTO)
        {
            using (SqlConnection connection =
                   new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_AddNewCustomer", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50)
                    .Value = customerDTO.FirstName;

                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50)
                    .Value = customerDTO.LastName;

                command.Parameters.Add("@Email", SqlDbType.NVarChar, 150)
                    .Value = customerDTO.Email;

                command.Parameters.Add("@Phone", SqlDbType.NVarChar, 11)
                    .Value = customerDTO.Phone.Trim();

                command.Parameters.Add("@City", SqlDbType.NVarChar, 100)
                    .Value = customerDTO.City;

                command.Parameters.Add("@Status", SqlDbType.NVarChar, 20)
                    .Value = customerDTO.Status;

                SqlParameter outputParaCustomerID =
                    new SqlParameter("@CustomerID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                command.Parameters.Add(outputParaCustomerID);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    return Convert.ToInt32(outputParaCustomerID.Value);
                }
                catch (SqlException)
                {
                    return -1;
                }
            }
        }

        public static bool IsTheEmailExists(string Email)
        {

            using (SqlConnection connection =
                   new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_IsEmailExists", connection))
            {
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@Email", SqlDbType.NVarChar, 150)
                    .Value = Email;

                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public static int UpdateCustomer(int customerID, CustomerAddDTO customerDTO)
        {

            using (SqlConnection connection =
                   new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_UpdateCustomer", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50)
                    .Value = customerDTO.FirstName;

                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50)
                    .Value = customerDTO.LastName;

                command.Parameters.Add("@Email", SqlDbType.NVarChar, 150)
                    .Value = customerDTO.Email;

                command.Parameters.Add("@Phone", SqlDbType.NVarChar, 11)
                    .Value = customerDTO.Phone;

                command.Parameters.Add("@City", SqlDbType.NVarChar, 100)
                    .Value = customerDTO.City;

                command.Parameters.Add("@Status", SqlDbType.NVarChar, 20)
                    .Value = customerDTO.Status;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;


                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public static bool DeleteCustomer(int customerID)
        {

            using (SqlConnection connection =
                  new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_DeleteCustomer", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;


                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
                catch (SqlException)
                {
                    throw;
                }

            }

        }

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

        public static async Task<IEnumerable<TopLoyaltyCustomerDTO>> ? GetTopLoyaltyCustomers()
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

    }
}