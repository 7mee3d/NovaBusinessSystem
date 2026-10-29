using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IEmployeesRepository
{
    Task<IEnumerable<EmployeeDetailsResponseDto>> GetAllAsync();
    Task<EmployeeResponseDto?> GetEmployeeAsync(int id);
    Task<int> AddEmployeeAsync(EmployeeCreateRequestDto employee);
    Task<bool> UpdateEmployeeAsync(int id, EmployeeUpdateRequestDto employee);
    Task<bool> DeleteEmployeeAsync(int id);


}
