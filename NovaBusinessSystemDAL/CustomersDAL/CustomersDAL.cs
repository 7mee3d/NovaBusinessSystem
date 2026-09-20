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

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerDTO = new CustomerDTO(
                        CustomerID,
                        (string)reader["Name"],
                        (string)reader["Email"],
                        (string)reader["Phone"],
                        (string)reader["City"],
                        (DateTime)reader["RegistrationDate"],
                        Convert.ToInt16(reader["LoyaltyPoints"]),
                        (bool)reader["Status"]

                        );
                    }
                }
            }

            return customerDTO;
        }


    }
}