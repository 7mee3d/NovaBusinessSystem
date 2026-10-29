
using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IEmployeesReportsService
{

    Task<IEnumerable<EmployeeSearchResponseDto>> GetEmployeeSearchAsync(EmployeeSearchRequestDto request);
    Task<IEnumerable<DepartmentEmployeeSummaryResponseDto>> GetDepartmentEmployeeSummaryAsync();
    Task<EmployeeSalarySummaryResponseDto> GetEmployeeSalarySummaryAsync();
    Task<IEnumerable<EmployeeStatusSummaryResponseDto>> GetEmployeeStatusSummaryAsync();
    Task<IEnumerable<EmployeeHiringSummaryResponseDto>> GetEmployeeHiringSummaryAsync();

}
