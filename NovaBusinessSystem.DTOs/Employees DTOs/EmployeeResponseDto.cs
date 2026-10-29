namespace NovaBusinessSystem.DTOs.Employees
{
    public record EmployeeResponseDto(
        int? EmployeeID,
        string FirstName,
        string LastName,
        string Department,
        string Manager,
        string JobTitle,
        decimal Salary,
        DateTime HireDate,
        string Phone,
        string Email,
        string Status
    );
}