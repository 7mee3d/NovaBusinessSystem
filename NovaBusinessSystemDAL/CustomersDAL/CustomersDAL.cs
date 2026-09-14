using System.Data;
using Microsoft.Data.SqlClient;

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
        public static bool FindCustomerBy(
    int CustomerID,
    ref string name,
    ref string email,
    ref string phone,
    ref string city,
    ref DateTime registrationDate,
    ref short loyaltyPoints,
    ref bool status
)
        {
            bool isFound = false;

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
                        isFound = true;

                        name = (string)reader["Name"];
                        email = (string)reader["Email"];
                        phone = (string)reader["Phone"];
                        city = (string)reader["City"];
                        registrationDate = (DateTime)reader["RegistrationDate"];
                        loyaltyPoints = Convert.ToInt16(reader["LoyaltyPoints"]);
                        status = (bool)reader["Status"];
                    }
                }
            }

            return isFound;
        }
    }
}