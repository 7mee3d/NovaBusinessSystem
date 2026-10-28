namespace NovaBusinessSystem.DTOs.Employees
{
    public record EmployeeDetailsResponseDto(
        int EmployeeID,
        string Name,
        string Department,
        string JobTitle,
        decimal Salary,
        string Status
    );
}