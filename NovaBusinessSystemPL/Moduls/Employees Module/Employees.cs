using System.Data;
using NovaBusinessSystemBL;
using nEnumeration;
using Microsoft.Data.SqlClient;

namespace EmployeesPL
{

  public class EmployeesPL
  {



    private static void PrintScreenMenuEmployeesModule(out byte ChoiseEmployeesModule)
    {
      System.Console.WriteLine("\n\n\n\n");
      Console.WriteLine("\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║              👨‍💼 EMPLOYEES              ║");
      Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
      Console.WriteLine("\t\t║                                          ║");
      Console.WriteLine("\t\t║  1. 📋 List Employees                    ║");
      Console.WriteLine("\t\t║  2. 🔎 Get Employee By ID                ║");
      Console.WriteLine("\t\t║  3. ➕ Add Employee                      ║");
      Console.WriteLine("\t\t║  4. ✏️  Update Employee                   ║");
      Console.WriteLine("\t\t║  5. 🗑️  Delete Employee                   ║");
      Console.WriteLine("\t\t║  6. 🔍 Search Employees                  ║");
      Console.WriteLine("\t\t║  7. 📊 Employee Report                   ║");
      Console.WriteLine("\t\t║                                          ║");
      Console.WriteLine("\t\t║  0. 🔙 Back                              ║");
      Console.WriteLine("\t\t║                                          ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

      System.Console.Write("\n\n\t\tSelect : ");

      try
      {
        ChoiseEmployeesModule = Convert.ToByte(Console.ReadLine());
      }

      catch (Exception ex)
      {
        Console.WriteLine(" \n\n\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine(" \t\t║             ❌ ERROR                     ║");
        Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
        ChoiseEmployeesModule = 0;

      }

    }

    private static void _EmployeesList()
    {

      Console.Clear();
      DataTable DT_AllEmployees = EmployeesBL.GetAllEmployees();

      System.Console.WriteLine($"\n\n\t\t {"ID",-10} {"Name",-35} {"Department",-20} {"Job Title",-30} {"Salary",-20} {"Status",-15}");
      System.Console.WriteLine("\t\t" + new string('-', 125));

      foreach (DataRow DR_Employee in DT_AllEmployees.Rows)
      {

        System.Console.WriteLine(
          $"\t\t {Convert.ToInt32(DR_Employee["EmployeeID"]),-10} {DR_Employee["FullName"].ToString(),-35} {DR_Employee["DepartmentName"].ToString(),-20} {DR_Employee["JobTitle"].ToString(),-30} {(Convert.ToDouble(DR_Employee["Salary"])).ToString("C"),-20} {DR_Employee["Status"].ToString(),-15}");
      }

      System.Console.WriteLine("\t\t" + new string('-', 125));

      System.Console.WriteLine($"\n\n\t\tTotal Employees : {DT_AllEmployees.Rows.Count}");

    }

    private static EmployeesBL _GetEmployeeBy(int EmployeeID)
    {

      EmployeesBL EmployeeInfo = EmployeesBL.FindEmployeeBy(EmployeeID);
      if (EmployeeInfo is not null)
      {
        System.Console.WriteLine("\n\n\n");
        Console.WriteLine(" \t\t╔══════════════════════════════════════════╗");
        Console.WriteLine(" \t\t║             EMPLOYEE DETAILS             ║");
        Console.WriteLine(" \t\t╠══════════════════════════════════════════╣");

        Console.WriteLine($"\t\t║ {"ID",-12}: {EmployeeInfo.ID,-27}║");
        Console.WriteLine($"\t\t║ {"Name",-12}: {string.Join(" ", EmployeeInfo.FirstName, EmployeeInfo.LastName),-27}║");
        Console.WriteLine($"\t\t║ {"Department",-12}: {EmployeeInfo.DepartmentInfo.DepartmentName.Trim(),-27}║");
        string FullNameManager = "Unknown";

        if (EmployeeInfo.ManagerID > 0)
        {
          EmployeesBL ManagerInfo = EmployeesBL.FindEmployeeBy(EmployeeInfo.ManagerID);
          FullNameManager = string.Join(" ", ManagerInfo.FirstName, ManagerInfo.LastName);
        }

        Console.WriteLine($"\t\t║ {"Manager",-12}: {FullNameManager.Trim(),-27}║");
        Console.WriteLine($"\t\t║ {"Job Title",-12}: {EmployeeInfo.JobTitle.Trim(),-27}║");
        Console.WriteLine($"\t\t║ {"Salary",-12}: {EmployeeInfo.Salary,-27:N2}║");
        Console.WriteLine($"\t\t║ {"Hire Date",-12}: {EmployeeInfo.HireDate,-27:dd/MM/yyyy}║");
        Console.WriteLine($"\t\t║ {"Phone",-12}: {EmployeeInfo.Phone.Trim(),-27}║");
        Console.WriteLine($"\t\t║ {"Email",-12}: {EmployeeInfo.Email.Trim(),-27}║");
        Console.WriteLine($"\t\t║ {"Status",-12}: {_GetStatusEmployee(EmployeeInfo.Status),-27}║");

        Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
        return EmployeeInfo;
      }
      else
      {
        Console.WriteLine(" \n\n\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine(" \t\t║             ❌ NOT FOUND                 ║");
        Console.WriteLine(" \t\t╠══════════════════════════════════════════╣");
        Console.WriteLine($"\t\t║ Employee with ID {EmployeeID} was not found.      ║");
        Console.WriteLine(" \t\t╚══════════════════════════════════════════╝");
      }

      return null;

    }

    private static void ReadInformationEmployees(EmployeesBL NewEmployee)
    {

      Console.Write($"\n\n\t\t{"First Name",-16}: ");

      string FirstName = Console.ReadLine();
      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(FirstName))
          isPass = false;
        else
        {
          foreach (char c in FirstName)
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
              isPass = false;
              break;
            }
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! First Name",-16}: ");
          FirstName = Console.ReadLine();
        }
        else
          break;
      }

      NewEmployee.FirstName = FirstName;

      Console.Write($"\t\t{"Last Name",-16}: ");

      string LastName = Console.ReadLine();
      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(LastName))
          isPass = false;
        else
        {
          foreach (char c in LastName)
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
              isPass = false;
              break;
            }
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! Last Name",-16}: ");
          LastName = Console.ReadLine();
        }
        else
          break;
      }

      NewEmployee.LastName = LastName;


      Console.Write($"\t\t{"Department ID",-16}: ");
      int deptID = 0;

      while (!int.TryParse(Console.ReadLine(), out deptID))
      {
        Console.Write($"\t\t{"Invalid! Department ID",-16}: ");
      }

      NewEmployee.DepartmentID = deptID;

      Console.Write($"\t\t{"Manager ID",-16}: ");
      int mangeID = 0;

      while (!int.TryParse(Console.ReadLine(), out mangeID))
        Console.Write($"\t\t{"Invalid! Manager ID",-16}: ");

      NewEmployee.ManagerID = mangeID;

      Console.Write($"\t\t{"Job Title",-16}: ");
      string JobTitle = Console.ReadLine();

      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(JobTitle))
          isPass = false;
        else
        {
          foreach (char c in JobTitle)
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
              isPass = false;
              break;
            }
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! Job Title",-16}: ");
          JobTitle = Console.ReadLine();
        }
        else
          break;
      }


      NewEmployee.JobTitle = JobTitle;

      Console.Write($"\t\t{"Salary",-16}: ");
      decimal newSalary = 0.0m;

      while (!decimal.TryParse(Console.ReadLine(), out newSalary) || newSalary < 0)
        Console.Write($"\t\t{"Invalid! Salary ",-16}: ");

      NewEmployee.Salary = newSalary;

      Console.Write($"\t\t{"Phone",-16}: ");

      string Phone = Console.ReadLine();

      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(Phone))
          isPass = false;
        else
        {
          foreach (char c in Phone)
            if (!char.IsDigit(c))
            {
              isPass = false;
              break;
            }
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! Phone",-16}: ");
          Phone = Console.ReadLine();
        }
        else
          break;
      }


      NewEmployee.Phone = Phone;

      Console.Write($"\t\t{"Email",-16}: ");

      string Email = Console.ReadLine();

      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(Email))
          isPass = false;
        else
        {
          if (!Email.Contains(".com") || !Email.Contains("@"))
            isPass = false;
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! Email ",-16}: ");
          Email = Console.ReadLine();
        }
        else
          break;
      }

      NewEmployee.Email = Email;

    }

    private static void _AddNewEmployee()
    {

      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║              ➕ ADD EMPLOYEE             ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

      EmployeesBL NewEmployee = new EmployeesBL();

      ReadInformationEmployees(NewEmployee);
      try
      {

        if (NewEmployee.SaveModeEmployees())
        {
          Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
          Console.WriteLine("\t\t║            ✅ EMPLOYEE ADDED            ║");
          Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

          Console.WriteLine($"\t\t║ ID           : {NewEmployee.ID,-26}║");
          Console.WriteLine($"\t\t║ First Name   : {NewEmployee.FirstName,-26}║");
          Console.WriteLine($"\t\t║ Last Name    : {NewEmployee.LastName,-26}║");
          Console.WriteLine($"\t\t║ Department ID: {NewEmployee.DepartmentID,-26}║");
          Console.WriteLine($"\t\t║ Manager ID   : {NewEmployee.ManagerID,-26}║");
          Console.WriteLine($"\t\t║ Job Title    : {NewEmployee.JobTitle,-26}║");
          Console.WriteLine($"\t\t║ Salary       : {NewEmployee.Salary,-26:N2}║");
          Console.WriteLine($"\t\t║ Hire Date    : {DateTime.Now,-26:dd/MM/yyyy}║");
          Console.WriteLine($"\t\t║ Phone        : {NewEmployee.Phone,-26}║");
          Console.WriteLine($"\t\t║ Email        : {NewEmployee.Email,-26}║");
          Console.WriteLine($"\t\t║ Status       : {_GetStatusEmployee(NewEmployee.Status),-26}║");
          Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
        }
      }
      catch (SqlException SEX)
      {
        Console.WriteLine("\n\n\t\t╔════════════════════════════════════════════════════╗");
        Console.WriteLine("\t\t║              ❌ EMPLOYEE NOT ADDED                 ║");
        Console.WriteLine("\t\t╠════════════════════════════════════════════════════╣");
        Console.WriteLine("\t\t║ Employee could not be added.                       ║");
        Console.WriteLine($"\t\t║ Reason: {SEX.Message,-42} ║");
        Console.WriteLine("\t\t╚════════════════════════════════════════════════════╝");
      }

    }

    private static string _GetStatusEmployee(Enumerations.EnStatus Status)
    {

      switch (Status)
      {
        case Enumerations.EnStatus._kACTIVE:
          return "Active";
        case Enumerations.EnStatus._kINACTIVE:
          return "Inactive";
        case Enumerations.EnStatus._kSUSPENDED:
          return "Suspended";
        default: return "";
      }

    }

    private static void _UpdateEmployee()
    {
      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║            ✏️ UPDATE EMPLOYEE            ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

      int EmployeeID = 0;

      System.Console.Write("\n\n\t\tEnter Employee ID: ");

      while (!int.TryParse(Console.ReadLine(), out EmployeeID))
        Console.Write($"\t\t{"Invalid! Employee ID",-16}: ");

      EmployeesBL InfoEmployee = _GetEmployeeBy(EmployeeID);

      if (InfoEmployee is not null)
      {
        ReadInformationEmployees(InfoEmployee);

        Console.Write($"\n\t\t{"Enter Status(Active:1 , Inactive:0 , Suspended:2)",-16}: ");
        byte status = 0;

        while (!byte.TryParse(Console.ReadLine(), out status))
          Console.Write($"\t\t{"Invalid! Status Employee",-16}: ");

        InfoEmployee.Status = (Enumerations.EnStatus)status;

        try
        {

          if (InfoEmployee.SaveModeEmployees())
          {
            Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
            Console.WriteLine("\t\t║         ✅ EMPLOYEE UPDATED              ║");
            Console.WriteLine("\t\t╠══════════════════════════════════════════╣");

            Console.WriteLine($"\t\t║ ID           : {InfoEmployee.ID,-26}║");
            Console.WriteLine($"\t\t║ First Name   : {InfoEmployee.FirstName,-26}║");
            Console.WriteLine($"\t\t║ Last Name    : {InfoEmployee.LastName,-26}║");
            Console.WriteLine($"\t\t║ Department ID: {InfoEmployee.DepartmentID,-26}║");
            Console.WriteLine($"\t\t║ Manager ID   : {InfoEmployee.ManagerID,-26}║");
            Console.WriteLine($"\t\t║ Job Title    : {InfoEmployee.JobTitle,-26}║");
            Console.WriteLine($"\t\t║ Salary       : {InfoEmployee.Salary,-26:N2}║");
            Console.WriteLine($"\t\t║ Hire Date    : {InfoEmployee.HireDate,-26:dd/MM/yyyy}║");
            Console.WriteLine($"\t\t║ Phone        : {InfoEmployee.Phone,-26}║");
            Console.WriteLine($"\t\t║ Email        : {InfoEmployee.Email,-26}║");
            Console.WriteLine($"\t\t║ Status       : {(_GetStatusEmployee(InfoEmployee.Status)),-26}║");

            Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
          }

        }
        catch (SqlException SEX)
        {
          Console.WriteLine("\n\n\t\t╔════════════════════════════════════════════════════╗");
          Console.WriteLine("\t\t║                  ❌ NOT FOUND                     ║");
          Console.WriteLine("\t\t╠════════════════════════════════════════════════════╣");
          Console.WriteLine("\t\t║ Employee could not be found.                       ║");
          Console.WriteLine($"\t\t║ Reason: {SEX.Message,-42} ║");
          Console.WriteLine("\t\t╚════════════════════════════════════════════════════╝");
        }
      }





    }

    public static void StartupEmployeesModule()
    {

      while (true)
      {

        Console.Clear();
        PrintScreenMenuEmployeesModule(out byte ChoiseEmployeesModule);

        switch ((Enumerations.EnCategoriesEmployees)ChoiseEmployeesModule)
        {

          case Enumerations.EnCategoriesEmployees._kLIST_EMPLOYEES:
            _EmployeesList();
            break;

          case Enumerations.EnCategoriesEmployees._kGET_EMPLOYEES_BY_ID:
            {
              Console.Clear();

              Console.WriteLine($"\t\t╔══════════════════════════════════════════╗");
              Console.WriteLine($"\t\t║          🔎 GET EMPLOYEE BY ID           ║");
              Console.WriteLine($"\t\t╚══════════════════════════════════════════╝");
              Console.WriteLine();
              Console.Write($"\n\n\t\tEnter Employee ID: ");
              int.TryParse(Console.ReadLine(), out int EmployeeID);
              _GetEmployeeBy(EmployeeID);
              break;

            }

          case Enumerations.EnCategoriesEmployees._kADD_EMPLOYEE:
            _AddNewEmployee();
            break;

          case Enumerations.EnCategoriesEmployees._kUPDATE_INFORMATION_EMPLOYEE:
            {
              _UpdateEmployee();
              break;
            }
        }

        System.Console.WriteLine("\n\n\t\tPress any key to continue...");
        Console.ReadKey();

      }
    }


  }

}