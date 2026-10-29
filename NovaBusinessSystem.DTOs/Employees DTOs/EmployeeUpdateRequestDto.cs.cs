using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Employees;

public class EmployeeUpdateRequestDto
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int DepartmentID { get; set; }

    [Range(1, int.MaxValue)]
    public int? ManagerID { get; set; }

    [Required]
    [StringLength(200)]
    public string JobTitle { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "9999999999999999.99")]
    public decimal Salary { get; set; }

    [Phone]
    [StringLength(30)]
    public string? Phone { get; set; }

    [EmailAddress]
    [StringLength(254)]
    public string? Email { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = string.Empty;
}