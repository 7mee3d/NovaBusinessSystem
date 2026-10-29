
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Services
{

    public class EmployeesService : IEmployeesService
    {

        private readonly IEmployeesRepository _repository;

        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            this._repository = employeesRepository;
        }

        public Task<IEnumerable<EmployeeDetailsResponseDto>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<int> AddEmployeeAsync(EmployeeCreateRequestDto employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            return _repository.AddEmployeeAsync(employee); ;
        }

        public Task<EmployeeResponseDto?> GetEmployeeAsync(int employeeID)
        {
            if (employeeID <= 0)
                throw new ArgumentOutOfRangeException("employee id is invalid ");

            return _repository.GetEmployeeAsync(employeeID);
        }
        public Task<bool> UpdateEmployeeAsync(int employeeID, EmployeeUpdateRequestDto employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            return _repository.UpdateEmployeeAsync(employeeID, employee); ;
        }

        public Task<bool> DeleteEmployeeAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("employee id is invalid ");

            return _repository.DeleteEmployeeAsync(id);
        }


    }
}