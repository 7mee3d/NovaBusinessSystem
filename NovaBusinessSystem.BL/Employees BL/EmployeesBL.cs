using System.Data;
using DataAccessLayer;
using NovaBusinessSystem.DTOs.Employees;
using NovaBusinessSystem.Enumeration;

namespace NovaBusinessSystem.BL;

public class EmployeesBL
{
    private readonly IEmployeesDAL _employeeDAL;
    private readonly IDepartmentDAL _departmentDAL;

    public EmployeesBL(IEmployeesDAL employeesDAL, IDepartmentDAL departmentDAL)
    {
        this._employeeDAL = employeesDAL;
        this._departmentDAL = departmentDAL;
    }

    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DepartmentID { get; set; }
    public int ManagerID { get; set; }
    public string JobTitle { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Enumerations.EnStatus Status { get; set; }

    public string GetStatusStr
    {
        get
        {
            switch (this.Status)
            {
                case Enumerations.EnStatus._kINACTIVE:
                    return "Inactive";
                case Enumerations.EnStatus._kACTIVE:
                    return "Active";
                case Enumerations.EnStatus._kSUSPENDED:
                    return "Suspended";
                default: return "Unknown";
            }
        }
    }

    public EmployeeResponseDto Dto
    {
        get
        {
            return new EmployeeResponseDto(
                ID,
                FirstName,
                LastName,
                _departmentName ?? "N/A",
                _managerName ?? "N/A",
                JobTitle,
                Salary,
                HireDate,
                Phone,
                Email,
                GetStatusStr
            );
        }
    }

    private string? _departmentName;
    private string? _managerName;

    public async Task LoadDtoDataAsync()
    {
        var department = await _departmentDAL.GetDepartmentAsync(DepartmentID);

        _departmentName = department?.DepartmentName;

        if (ManagerID > 0)
        {
            var manager = await FindEmployeeByAsync(ManagerID);

            _managerName = manager is null
                ? "N/A"
                : $"{manager.FirstName} {manager.LastName}";
        }
        else
        {
            _managerName = "N/A";
        }
    }


    public Enumerations.EnMode enMode { get; set; }

    public EmployeesBL()
    {
        this.ID = default;
        this.FirstName = default;
        this.LastName = default;
        this.DepartmentID = default;
        this.ManagerID = default;
        this.JobTitle = default;
        this.Salary = default;
        this.HireDate = default;
        this.Salary = default;
        this.Phone = default;
        this.Email = default;
        this.Status = default;
        this.enMode = Enumerations.EnMode._kADD;

    }

    public EmployeesBL(EmployeeResponseDto employee, Enumerations.EnMode mode)
    {
        this.ID = employee.EmployeeID;
        this._departmentName = employee.Department ;
        this._managerName = employee.Manager;
        this.FirstName = employee.FirstName;
        this.LastName = employee.LastName;
        this.JobTitle = employee.JobTitle;
        this.Salary = employee.Salary;
        this.HireDate = employee.HireDate;
        this.Phone = employee.Phone ?? string.Empty;
        this.Email = employee.Email ?? string.Empty;
        this.enMode = mode;
    }

    public Task<IEnumerable<EmployeeDetailsResponseDto>> GetEmployeeDetailsResponsesAsync()
    {
        return _employeeDAL.GetAllEmployeeDetailsAsync();
    }

    public async Task<EmployeesBL?> FindEmployeeByAsync(
        int employeeID)
    {
        EmployeeResponseDto? employee =
            await _employeeDAL.GetEmployeeAsync(employeeID);

        if (employee is null)
            return null;

        return new EmployeesBL(employee, Enumerations.EnMode._kUPDATE);
    }

    private bool _AddNewEmployee()
    {

        this.ID = EmployeesDAL.AddNewEmployee(this.FirstName, this.LastName, this.DepartmentID, this.ManagerID, this.JobTitle, this.Salary, this.Phone, this.Email);
        return this.ID > 0;
    }

    private bool _UpdateEmployee()
    {
        string Status = "";

        switch (this.Status)
        {
            case Enumerations.EnStatus._kACTIVE:
                Status = "Active";
                break;
            case Enumerations.EnStatus._kINACTIVE:
                Status = "Inactive";
                break;
            case Enumerations.EnStatus._kSUSPENDED:
                Status = "Suspended";
                break;

        }
        return EmployeesDAL.UpdateEmployee(this.ID, this.FirstName, this.LastName, this.DepartmentID, this.ManagerID, this.JobTitle, this.Salary, this.Phone, this.Email, Status);
    }

    public static bool DeleteEmployee(int EmployeeID) => EmployeesDAL.DeleteEmployee(EmployeeID);

    public bool SaveModeEmployees()
    {
        switch (this.enMode)
        {
            case Enumerations.EnMode._kADD:
                {
                    if (_AddNewEmployee())
                    {
                        this.enMode = Enumerations.EnMode._kUPDATE;
                        return true;
                    }
                    else return false;

                }

            case Enumerations.EnMode._kUPDATE:
                return _UpdateEmployee();

            default: return false;
        }
    }

    public static DataTable GetDepartmentSammary() => EmployeesDAL.GetDepartmentSammary();

    public static DataTable GetSalarySummary() => EmployeesDAL.GetSalarySummary();

    public static Dictionary<string, int> GetEmployeeStatus() => EmployeesDAL.GetEmployeeStatus();
    public static Dictionary<string?, int?> GetHiringSummary() => EmployeesDAL.GetHiringSummary();
}

