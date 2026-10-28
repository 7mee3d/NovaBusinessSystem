
using NovaBusinessSystem.DTOs.Employees;

public interface IEmployeesDAL
{
    Task<IEnumerable<EmployeeDetailsResponseDto>> GetAllEmployeeDetailsAsync();
}