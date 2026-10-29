
using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Employees;

public class EmployeeCreateRequestDto
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string LastName { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int DepartmentID { get; set; }

    [Range(0, int.MaxValue)]
    public int? ManagerID { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string JobTitle { get; set; } = string.Empty;

    [Required]
    [Range(typeof(decimal), "0.01", "9999999999999999.99")]
    public decimal Salary { get; set; }

    [Phone]
    [StringLength(30, MinimumLength = 1)]
    public string? Phone { get; set; } = string.Empty;

    [EmailAddress]
    [StringLength(254, MinimumLength = 1)]
    public string ? Email { get; set; } = string.Empty;
}
