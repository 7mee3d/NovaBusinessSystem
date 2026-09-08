using System.Data;
using DataAccessLayer;
using nEnumeration;
namespace NovaBusinessSystemBL;

public class DepartmentsBL
{
    public DepartmentsBL()
    {
        this.DepartmentID = default;
        this.DepartmentName = default;
        this.Budget = default;
        this.Location = default;
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

    public static DepartmentsBL GetDepartmentBy(int DepartmentID)
    {
        string DepartmentName = "", Location = "";
        decimal Budget = 0.0m;

        bool IsFound = DepartmentsDAL.GetDepartmentBy(DepartmentID, ref DepartmentName, ref Location, ref Budget);

        if (IsFound)
            return new DepartmentsBL(DepartmentID, DepartmentName, Location, Budget);
        else return null;


    }

}