using System.Data;
using DataAccessLayer;
using nEnumeration;
namespace NovaBusinessSystemBL;

public class EmployeesBL
{

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

    private EmployeesBL _InfoManager = null;
    public EmployeesBL ManagerInfo
    {
        get
        {
            if (_InfoManager is null)
                _InfoManager = FindEmployeeBy(this.ManagerID);

            return _InfoManager;
        }

    }
    private DepartmentsBL _DepartmentInfo = null;
    public DepartmentsBL DepartmentInfo
    {

        get
        {
            if (_DepartmentInfo is null)
                _DepartmentInfo = DepartmentsBL.GetDepartmentBy(DepartmentID);

            return _DepartmentInfo;
        }
    }

    public nEnumeration.Enumerations.EnMode enMode { get; set; }

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

    public EmployeesBL(
        int EmployeeID,
        string FirstName,
        string lastName,
        int DepartmentID,
        int ManagerID,
        string jobTitle,
        decimal salary,
        DateTime hireDate,
        string phone,
        string email,
        Enumerations.EnStatus status)
    {
        this.ID = EmployeeID;
        this.FirstName = FirstName;
        this.LastName = lastName;
        this.DepartmentID = DepartmentID;
        this.ManagerID = ManagerID;
        this.JobTitle = jobTitle;
        this.Salary = salary;
        this.HireDate = hireDate;
        this.Phone = phone;
        this.Email = email;
        this.Status = status;
        this.enMode = Enumerations.EnMode._kUPDATE;
    }

    public static DataTable GetAllEmployees(

        string? FullName = null,
        string? DepartmentName = null,
        string? JobTitle = null,
        string? Status = null

        )
            => EmployeesDAL.GetListEmployees(FullName, DepartmentName, JobTitle, Status);


    public static EmployeesBL FindEmployeeBy(int EmployeeID)
    {

        string FirstName = "", LastName = "", JobTitle = "", Phone = "", Email = "";
        decimal Salary = 0.0m;
        DateTime HireDate = DateTime.Now;
        byte Status = 0;
        int DepartmentID = 0, ManagerID = 0;

        bool IsFound = EmployeesDAL.GetEmployeeBy(
            EmployeeID,
            ref FirstName,
            ref LastName,
            ref DepartmentID,
            ref ManagerID,
            ref JobTitle,
            ref Salary,
            ref HireDate,
            ref Phone,
            ref Email,
            ref Status
           );

        if (IsFound)
            return new EmployeesBL(
            EmployeeID,
            FirstName,
            LastName,
            DepartmentID,
            ManagerID,
            JobTitle,
            Salary,
            HireDate,
            Phone,
            Email,
            (Enumerations.EnStatus)Status);

        else return null;


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
    
}

