using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;


namespace NovaBusinessSystem.DAL.Repositories;

public class EmployeesRepository : IEmployeesRepository
{
    public async Task<IEnumerable<EmployeeDetailsResponseDto>> GetAllAsync()
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

    private static void AddEmployeeParameters(SqlCommand command, EmployeeCreateRequestDto employee)
    {
        command.Parameters.Add(
            "@FirstName", SqlDbType.NVarChar, 100).Value =
            employee.FirstName;

        command.Parameters.Add(
            "@LastName", SqlDbType.NVarChar, 100).Value =
            employee.LastName;

        command.Parameters.Add(
            "@DepartmentID", SqlDbType.Int).Value =
            employee.DepartmentID;

        command.Parameters.Add(
            "@ManagerID", SqlDbType.Int).Value =
            employee.ManagerID == 0 || employee.ManagerID is null ? DBNull.Value : employee.ManagerID;

        command.Parameters.Add(
            "@JobTitle", SqlDbType.NVarChar, 200).Value =
            employee.JobTitle;

        var salaryParameter = command.Parameters.Add(
            "@Salary", SqlDbType.Decimal);

        salaryParameter.Precision = 10;
        salaryParameter.Scale = 2;
        salaryParameter.Value = employee.Salary;

        command.Parameters.Add(
            "@Phone", SqlDbType.Char, 11).Value =
            employee.Phone == "" || employee.Phone is null ? DBNull.Value : employee.Phone;

        command.Parameters.Add(
            "@Email", SqlDbType.VarChar, -1).Value =
            employee.Email == "" || employee.Email is null ? DBNull.Value : employee.Email;
    }

    public async Task<int> AddEmployeeAsync(EmployeeCreateRequestDto employee)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_AddNewEmployee]", connection)
        {

            CommandType = CommandType.StoredProcedure
        };

        AddEmployeeParameters(command, employee);

        var employeeIdParameter = command.Parameters.Add("@EmployeeID", SqlDbType.Int);

        employeeIdParameter.Direction = ParameterDirection.Output;

        await connection.OpenAsync();

        await command.ExecuteNonQueryAsync();

        return Convert.ToInt32(employeeIdParameter.Value);
    }

    public async Task<EmployeeResponseDto?> GetEmployeeAsync(int employeeID)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

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
            reader.IsDBNull(managerName) ? null : reader.GetString(managerName),
            reader.GetString(jobTitle),
            reader.GetDecimal(salary),
            reader.GetDateTime(hireDate),
            reader.IsDBNull(phone) ? null : reader.GetString(phone),
            reader.IsDBNull(email) ? null : reader.GetString(email),
            reader.GetString(status)
        );
    }

    public async Task<bool> UpdateEmployeeAsync(int id, EmployeeUpdateRequestDto employee)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].usp_UpdateEmployee", connection)
        {
            CommandType = CommandType.StoredProcedure
        };


        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = id;

        command.Parameters.Add(
            "@FirstName", SqlDbType.NVarChar, 100).Value =
            employee.FirstName;

        command.Parameters.Add(
            "@LastName", SqlDbType.NVarChar, 100).Value =
            employee.LastName;

        command.Parameters.Add(
            "@DepartmentID", SqlDbType.Int).Value =
            employee.DepartmentID;

        command.Parameters.Add(
            "@ManagerID", SqlDbType.Int).Value =
            employee.ManagerID == 0 || employee.ManagerID is null ? DBNull.Value : employee.ManagerID;

        command.Parameters.Add(
            "@JobTitle", SqlDbType.NVarChar, 200).Value =
            employee.JobTitle;

        var salaryParameter = command.Parameters.Add(
            "@Salary", SqlDbType.Decimal);

        salaryParameter.Precision = 10;
        salaryParameter.Scale = 2;
        salaryParameter.Value = employee.Salary;

        command.Parameters.Add(
            "@Phone", SqlDbType.Char, 11).Value =
            employee.Phone == "" || employee.Phone is null ? DBNull.Value : employee.Phone;

        command.Parameters.Add(
            "@Email", SqlDbType.VarChar, -1).Value =
            employee.Email == "" || employee.Email is null ? DBNull.Value : employee.Email;

        command.Parameters.Add(
                    "@Status", SqlDbType.VarChar).Value = employee.Status;


        await connection.OpenAsync();

        return await command.ExecuteNonQueryAsync() > 0;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].usp_DeleteEmployee", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = id;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        if (result is not null && int.TryParse(result.ToString(), out int r))
            return r > 0;
        else return false;



    }
    public async Task<IEnumerable<EmployeeSearchResponseDto>> GetEmployeeSearchAsync(
        EmployeeSearchRequestDto request)
    {
        List<EmployeeSearchResponseDto> employeeSearches = new();

        using var connection = new SqlConnection(
            HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand(
            "[dbo].usp_SearchEmployee", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@FullName", SqlDbType.NVarChar, 200).Value =
            (object?)request.FullName ?? DBNull.Value;

        command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 150).Value =
            (object?)request.DepartmentName ?? DBNull.Value;

        command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 150).Value =
            (object?)request.JobTitle ?? DBNull.Value;

        command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value =
            (object?)request.Status ?? DBNull.Value;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            employeeSearches.Add(new EmployeeSearchResponseDto(
                 reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                reader.GetString(reader.GetOrdinal("FullName")),
                reader.GetString(reader.GetOrdinal("DepartmentName")),
                reader.GetString(reader.GetOrdinal("JobTitle")),
                reader.GetString(reader.GetOrdinal("Status"))
            ));
        }

        return employeeSearches;
    }
}



