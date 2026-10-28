using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Employees;

namespace DataAccessLayer;

public class EmployeesDAL : IEmployeesDAL
{
    public async Task<IEnumerable<EmployeeDetailsResponseDto>> GetAllEmployeeDetailsAsync()
    {
        List<EmployeeDetailsResponseDto> employees = new();

        using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using SqlCommand command = new SqlCommand("[dbo].[usp_ListEmployees]", connection);

        await connection.OpenAsync();

        using SqlDataReader reader = await command.ExecuteReaderAsync();

        var employeeID = reader.GetOrdinal("EmployeeID");
        var name = reader.GetOrdinal("FullName");
        var department = reader.GetOrdinal("DepartmentName");
        var jobTitle = reader.GetOrdinal("JobTitle");
        var salary = reader.GetOrdinal("Salary");
        var status = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            employees.Add(new EmployeeDetailsResponseDto(
                reader.GetInt32(employeeID),
                reader.GetString(name),
                reader.GetString(department),
                reader.GetString(jobTitle),
                reader.GetDecimal(salary),
                reader.GetString(status)
            ));
        }

        return employees;
    }

    public async Task<EmployeeResponseDto?> GetEmployeeAsync(int employeeID)
    {
        
        using var connection = new SqlConnection( HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_GetEmployeeByID]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employeeID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        var firstName = reader.GetOrdinal("FirstName");
        var lastName = reader.GetOrdinal("LastName");
        var departmentID = reader.GetOrdinal("DepartmentName");
        var managerName = reader.GetOrdinal("ManagerName");
        var jobTitle = reader.GetOrdinal("JobTitle");
        var salary = reader.GetOrdinal("Salary");
        var hireDate = reader.GetOrdinal("HireDate");
        var phone = reader.GetOrdinal("Phone");
        var email = reader.GetOrdinal("Email");
        var status = reader.GetOrdinal("Status");

        return new EmployeeResponseDto(
            employeeID,
            reader.GetString(firstName),
            reader.GetString(lastName),
            reader.GetString(departmentID),
            reader.GetString(managerName),
            reader.GetString(jobTitle),
            reader.GetDecimal(salary),
            reader.GetDateTime(hireDate),
            reader.IsDBNull(phone) ? null : reader.GetString(phone),
            reader.IsDBNull(email) ? null : reader.GetString(email),
            reader.GetString(status)
        );
    }

    public static int AddNewEmployee(
         string firstName,
         string lastName,
         int departmentID,
         int managerID,
         string jobTitle,
         decimal salary,
         string phone,
         string email
    )
    {
        int EmployeeID = -1;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_AddNewEmployee", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = firstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = lastName;
            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
            command.Parameters.Add("@ManagerID", SqlDbType.Int).Value = managerID;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 200).Value = jobTitle;

            SqlParameter paramSalary =
                command.Parameters.Add("@Salary", SqlDbType.Decimal);

            paramSalary.Precision = 10;
            paramSalary.Scale = 2;
            paramSalary.Value = salary;

            command.Parameters.Add("@Phone", SqlDbType.Char, 11).Value = phone;
            command.Parameters.Add("@Email", SqlDbType.VarChar, -1).Value = email;

            SqlParameter paramEmployeeID =
                command.Parameters.Add("@EmployeeID", SqlDbType.Int);

            paramEmployeeID.Direction = ParameterDirection.Output;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                EmployeeID = Convert.ToInt32(paramEmployeeID.Value);
            }
            catch (SqlException SEX)
            {
                if (SEX.Number >= 50001)
                    EmployeeID = -1;

                throw;
            }
        }

        return EmployeeID;
    }


    public static bool UpdateEmployee(
        int EmployeeID,
         string firstName,
         string lastName,
         int departmentID,
         int managerID,
         string jobTitle,
         decimal salary,
         string phone,
         string email,
         string Status
    )
    {

        bool IsUpdated = false;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_UpdateEmployee", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = firstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = lastName;
            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
            command.Parameters.Add("@ManagerID", SqlDbType.Int).Value = managerID;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 200).Value = jobTitle;
            command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = salary;
            command.Parameters.Add("@Phone", SqlDbType.Char, 11).Value = phone;
            command.Parameters.Add("@Email", SqlDbType.VarChar, -1).Value = email;
            command.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = Status;


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                IsUpdated = true;
            }
            catch (SqlException SEX)
            {
                if (SEX.Number >= 50001)
                    IsUpdated = false;

                throw;
            }
        }

        return IsUpdated;
    }

    public static bool DeleteEmployee(int EmployeeID)
    {

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_DeleteEmployee", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
            catch (SqlException SEX)
            {
                if (SEX.Number == 50001)
                    return false;

                throw;
            }


        }

    }

    public static DataTable GetDepartmentSammary()
    {
        DataTable DT_GetAllDepartmentSammary = new DataTable();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_DepartmentSummary", connection))
        {
            command.CommandType = CommandType.StoredProcedure;


            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                    if (reader.HasRows)
                        DT_GetAllDepartmentSammary.Load(reader);


            }
            catch { }

        }

        return DT_GetAllDepartmentSammary;
    }

    public static DataTable GetSalarySummary()
    {
        DataTable DT_SalarySummary = new DataTable();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_SalarySummary", connection))
        {

            command.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                    if (reader.HasRows)
                        DT_SalarySummary.Load(reader);
            }
            catch { }
            ;

        }

        return DT_SalarySummary;
    }


    public static Dictionary<string, int> GetEmployeeStatus()
    {
        Dictionary<string, int> AllStatusEmployees = new Dictionary<string, int>();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_EmployeeStatus", connection))
        {

            command.CommandType = CommandType.StoredProcedure;

            try
            {

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        AllStatusEmployees.Add(reader["Status"].ToString()!, Convert.ToInt32(reader["Count"]));
                }

            }
            catch
            {

            }
            ;

        }

        return AllStatusEmployees;
    }

    public static Dictionary<string?, int?> GetHiringSummary()
    {
        Dictionary<string?, int?> AllHiringSummary = new Dictionary<string?, int?>();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_HiringSummary", connection))
        {
            command.CommandType = CommandType.StoredProcedure;


            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                        AllHiringSummary.Add(reader["HireYear"].ToString()!, Convert.ToInt32(reader["Employees Hired"]));

            }
            catch
            {

            }
            ;
        }

        return AllHiringSummary;

    }
}