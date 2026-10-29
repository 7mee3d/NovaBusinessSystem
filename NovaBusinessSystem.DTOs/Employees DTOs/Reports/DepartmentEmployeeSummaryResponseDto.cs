
using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Employees;

public record DepartmentEmployeeSummaryResponseDto(
    string DepartmentName,
    int TotalEmployees,
    decimal AvgSalary
);