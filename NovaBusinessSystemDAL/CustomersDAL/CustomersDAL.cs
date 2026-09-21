using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystemDTOs;

namespace nCustomersDAL
{

    public class CustomersDAL
    {

        public static DataTable GetAllCustomersList()
        {
            DataTable DT_AllCustomers = new DataTable();


            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetCustomers", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllCustomers.Load(reader);

                }
                catch { throw; }
                ;
            }

            return DT_AllCustomers;

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


        public static int AddNewCustomer(CustomerDTO customerDTO)
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

                command.Parameters.Add("@Phone", SqlDbType.NChar, 11)
                    .Value = customerDTO.Phone;

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

    }

}
