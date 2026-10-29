
using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Employees;

public class EmployeeSearchRequestDto
{
    [MaxLength(200)]
    public string? FullName { get; set; }

    [MaxLength(150)]
    public string? DepartmentName { get; set; }

    [MaxLength(150)]
    public string? JobTitle { get; set; }

    [MaxLength(20)]
    public string? Status { get; set; }
}
