
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Services
{

    public class EmployeesReportsService : IEmployeesReportsService
    {

        private readonly IEmployeesReportsRepository _repository;

        public EmployeesReportsService(IEmployeesReportsRepository employeesReportsRepository)
        {
            this._repository = employeesReportsRepository;
        }

        public Task<IEnumerable<EmployeeSearchResponseDto>> GetEmployeeSearchAsync(EmployeeSearchRequestDto request)
        {
            ArgumentNullException.ThrowIfNull(request);

            return _repository.GetEmployeeSearchAsync(request);
        }

        public Task<IEnumerable<DepartmentEmployeeSummaryResponseDto>> GetDepartmentEmployeeSummaryAsync()
        {
            return _repository.GetDepartmentEmployeeSummaryAsync();
        }

        public Task<EmployeeSalarySummaryResponseDto> GetEmployeeSalarySummaryAsync()
        {
            return _repository.GetEmployeeSalarySummaryAsync();
        }

        public Task<IEnumerable<EmployeeStatusSummaryResponseDto>> GetEmployeeStatusSummaryAsync()
        {
            return _repository.GetEmployeeStatusSummaryAsync();
        }

        public Task<IEnumerable<EmployeeHiringSummaryResponseDto>> GetEmployeeHiringSummaryAsync()
        {
            return _repository.GetEmployeeHiringSummaryAsync();
        }

    }
}