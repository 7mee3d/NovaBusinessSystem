
namespace NovaBusinessSystem.DTOs.Employees;

public record EmployeeSearchResponseDto(
    int EmployeeID,
    string FullName,
    string DepartmentName,
    string JobTitle,
    string Status
);