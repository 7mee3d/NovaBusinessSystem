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

                }catch{throw;};
            }

            return DT_AllCustomers;
            
        }
    }
}