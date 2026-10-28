using DataAccessLayer;
namespace NovaBusinessSystem.BL.Departments;

public class DepartmentsBL
{
    private readonly IDepartmentDAL _departmentDAL;

    public DepartmentsBL(IDepartmentDAL departmentDAL)
    {
        this._departmentDAL = departmentDAL;
    }

    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; }
    public string Location { get; set; }
    public decimal Budget { get; set; }
    public DepartmentsBL(
         int DepartmentID,
         string DepartmentName,
         string Location,
         decimal Budget)
    {
        this.DepartmentID = DepartmentID;
        this.DepartmentName = DepartmentName;
        this.Budget = Budget;
        this.Location = Location;
    }

    public async Task<DepartmentsBL> GetDepartmentBy(int DepartmentID)
    {
        string DepartmentName = "", Location = "";
        decimal Budget = 0.0m;

        var departmnet = await this._departmentDAL.GetDepartmentAsync(DepartmentID);

        if (departmnet is not null)
            return new DepartmentsBL(DepartmentID, DepartmentName, Location, Budget);
        else return null;


    }

}