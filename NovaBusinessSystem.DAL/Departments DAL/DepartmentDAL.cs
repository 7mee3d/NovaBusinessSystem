using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Departments;

namespace DataAccessLayer;

public class DepartmentsDAL : IDepartmentDAL
{

    public async Task<DepartmentResponseDto?> GetDepartmentAsync(int departmentID)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_GetDepartmentByID]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };


        command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

        await connection.OpenAsync();

        using SqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        var departmentIDOrdinal = reader.GetOrdinal("DepartmentID");
        var departmentName = reader.GetOrdinal("DepartmentName");
        var location = reader.GetOrdinal("Location");
        var budget = reader.GetOrdinal("Budget");

        return new DepartmentResponseDto(
            reader.GetInt32(departmentIDOrdinal),
            reader.GetString(departmentName),
            reader.GetString(location),
            reader.GetDecimal(budget)
        );
    }
}