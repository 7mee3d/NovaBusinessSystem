using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class DepartmentsDAL
{

    public static bool GetDepartmentBy(
        int DepartmentID,
        ref string DepartmentName,
        ref string Location,
        ref decimal Budget
        )
    {

        bool IsFound = false;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_GetDepartmentByID", connection))
        {

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;

            SqlParameter paramDepartmentName = command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 150);
            paramDepartmentName.Direction = ParameterDirection.Output;

            SqlParameter paramLocation = command.Parameters.Add("@Location", SqlDbType.NVarChar, 300);
            paramLocation.Direction = ParameterDirection.Output;

            SqlParameter paramBudget = command.Parameters.Add("@Budget", SqlDbType.Decimal);
            paramBudget.Precision = 10;
            paramBudget.Scale = 2;

            paramBudget.Direction = ParameterDirection.Output;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                DepartmentName = (string)paramDepartmentName.Value;
                Location = (string)paramLocation.Value;
                Budget = (decimal)paramBudget.Value;

                IsFound = true;

            }
            catch (SqlException SEX)
            {
                if (SEX.Number >= 50001)
                    IsFound = false;

                throw;


            }
        }
        return IsFound;
    }
}