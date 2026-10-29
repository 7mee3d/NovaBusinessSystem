using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;


namespace NovaBusinessSystem.DAL.Repositories;

public class EmployeesReportsRepository : IEmployeesReportsRepository
{

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

    public async Task<IEnumerable<DepartmentEmployeeSummaryResponseDto>> GetDepartmentEmployeeSummaryAsync()
    {
        List<DepartmentEmployeeSummaryResponseDto> summaries = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_DepartmentSummary]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };


        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int departmentNameOrdinal = reader.GetOrdinal("DepartmentName");
        int totalEmployeesOrdinal = reader.GetOrdinal("TotalEmployees");
        int avgSalaryOrdinal = reader.GetOrdinal("AvgSalary");

        while (await reader.ReadAsync())
        {
            summaries.Add(new DepartmentEmployeeSummaryResponseDto(
                reader.GetString(departmentNameOrdinal),
                reader.GetInt32(totalEmployeesOrdinal),
                reader.GetDecimal(avgSalaryOrdinal)
            ));
        }

        return summaries;

    }

    public async Task<EmployeeSalarySummaryResponseDto> GetEmployeeSalarySummaryAsync()
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_SalarySummary]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        return new EmployeeSalarySummaryResponseDto(
            reader.GetDecimal(reader.GetOrdinal("MinimumSalary")),
            reader.GetDecimal(reader.GetOrdinal("MaximumSalary")),
            reader.GetDecimal(reader.GetOrdinal("AverageSalary")),
            reader.GetDecimal(reader.GetOrdinal("TotalSalary"))
        );
    }

    public async Task<IEnumerable<EmployeeStatusSummaryResponseDto>> GetEmployeeStatusSummaryAsync()
    {
        List<EmployeeStatusSummaryResponseDto> employeeStatuses = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_EmployeeStatus]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();
        int statusOrdinal = reader.GetOrdinal("Status");
        int countOrdinal = reader.GetOrdinal("Count");

        while (await reader.ReadAsync())
        {
            employeeStatuses.Add(new EmployeeStatusSummaryResponseDto(
                reader.GetString(statusOrdinal),
                reader.GetInt32(countOrdinal)
            ));
        }

        return employeeStatuses;
    }

    public async Task<IEnumerable<EmployeeHiringSummaryResponseDto>> GetEmployeeHiringSummaryAsync()
    {
        List<EmployeeHiringSummaryResponseDto> employeeHiringSummaries = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_HiringSummary]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };


        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();


        int hireYearOrdinal = reader.GetOrdinal("HireYear");
        int employeesHiredOrdinal = reader.GetOrdinal("EmployeesHired");

        while (await reader.ReadAsync())
        {
            employeeHiringSummaries.Add(new EmployeeHiringSummaryResponseDto(
                reader.GetInt32(hireYearOrdinal),
                reader.GetInt32(employeesHiredOrdinal)
            ));
        }

        return employeeHiringSummaries;
    }

}




