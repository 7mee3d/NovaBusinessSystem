using System.Data;
using NovaBusinessSystemBL;
using nEnumeration;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;


namespace EmployeesPL
{

  public class EmployeesPL
  {


    private static void _ShowNotFoundMessage(string MessageReason, string MessageHeader, string MessageBody)
    {
      Console.WriteLine("\n\n\t\t╔════════════════════════════════════════════════════════════════════════╗");
      Console.WriteLine($"\t\t║                  {MessageHeader}                                 ║");
      Console.WriteLine("\t\t╠════════════════════════════════════════════════════════════════════════╣");
      Console.WriteLine($"\t\t║ {MessageBody,-50}                             ║");
      Console.WriteLine($"\t\t║ Reason: {MessageReason,-50}  ║");
      Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════╝");
    }

    private static void PrintDetail(string label, object? value)
    {
      const int ContentWidth = 50;

      string Text = $"{label,-13} : {value ?? " "}";

      if (Text.Length > ContentWidth)
        Text = Text[..ContentWidth];


      Console.WriteLine($"\t\t║ {Text,-48}║");
    }
    private static void _ShowSccessMessageAndShowInformationEmployee(EmployeesBL informationEmployee, string message)
    {

      int width = 50;
      int contentWidth = width - 2;

      int paddingLeft = (contentWidth - message.Length) / 2;
      int paddingRight = contentWidth - message.Length - paddingLeft - 1 ;


      Console.WriteLine("\n\n\t\t╔═════════════════════════════════════════════════╗");
      Console.WriteLine($"\t\t║{new string(' ', paddingLeft)}{message}{new string(' ', paddingRight)} ║");
      Console.WriteLine("\t\t╚═════════════════════════════════════════════════╝");

      PrintDetail("ID", informationEmployee.ID);
      PrintDetail("First Name", informationEmployee.FirstName);
      PrintDetail("Last Name", informationEmployee.LastName);
      PrintDetail("Department ID", informationEmployee.DepartmentID);
      PrintDetail("Manager ID", informationEmployee.ManagerID);
      PrintDetail("Job Title", informationEmployee.JobTitle.Trim());
      PrintDetail("Salary", $"{informationEmployee.Salary:N2}");
      PrintDetail("Hire Date", DateTime.Now.ToString("dd/MM/yyyy"));
      PrintDetail("Phone", informationEmployee.Phone);
      PrintDetail("Email", informationEmployee.Email);
      PrintDetail("Status", _GetStatusEmployee(informationEmployee.Status));

      Console.WriteLine("\t\t╚═════════════════════════════════════════════════╝");
    }

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

      while (!Byte.TryParse(Console.ReadLine(), out ChoiseEmployeesModule) || ChoiseEmployeesModule > 7)
        System.Console.Write("\t\tInvalid Choice Employees : ");

    }

    private static void _EmployeesList(string? FullName = null, string? DepartmentName = null, string? JobTitle = null, string? Status = null)
    {

      Console.Clear();
      DataTable DT_AllEmployees = EmployeesBL.GetAllEmployees(FullName, DepartmentName, JobTitle, Status);

      if (DT_AllEmployees is null || DT_AllEmployees.Rows.Count == 0)
      {
        Console.WriteLine("\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine("\t\t║             ❌ NO RESULTS                ║");
        Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
        Console.WriteLine("\t\t║ No employees matched your search.        ║");
        Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n\n");

        return;
      }


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
        _ShowSccessMessageAndShowInformationEmployee(EmployeeInfo, "EMPLOYEE DETAILS");
        return EmployeeInfo;
      }
      else
      {
        _ShowNotFoundMessage($"Employee with ID {EmployeeID} was not found.", "❌ NOT FOUND", "Employee could not be found.");
      }

      return null;

    }

    private static void ReadInformationEmployees(EmployeesBL NewEmployee)
    {

      Console.Write($"\n\n\t\t{"First Name",-16}: ");

      string? FirstName = Console.ReadLine()!;

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
          FirstName = Console.ReadLine()!;
        }
        else
          break;
      }

      NewEmployee.FirstName = FirstName!;

      Console.Write($"\t\t{"Last Name",-16}: ");

      string? LastName = Console.ReadLine();
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

      NewEmployee.LastName = LastName!;


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

      string? JobTitle = Console.ReadLine()!;

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


      NewEmployee.JobTitle = JobTitle!;

      Console.Write($"\t\t{"Salary",-16}: ");
      decimal newSalary = 0.0m;

      while (!decimal.TryParse(Console.ReadLine(), out newSalary) || newSalary < 0)
        Console.Write($"\t\t{"Invalid! Salary ",-16}: ");

      NewEmployee.Salary = newSalary;

      Console.Write($"\t\t{"Phone",-16}: ");

      string? Phone = Console.ReadLine()!;

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


      NewEmployee.Phone = Phone!;

      Console.Write($"\t\t{"Email",-16}: ");

      string Email = Console.ReadLine()!;

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
          Email = Console.ReadLine()!;
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
          _ShowSccessMessageAndShowInformationEmployee(NewEmployee, "✅ EMPLOYEE ADDED");
        }
      }
      catch (SqlException SEX)
      {
        _ShowNotFoundMessage($"Employee with ID {SEX.Message} was not found.", "❌ EMPLOYEE NOT ADDED", "Employee could not be added.");
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

        while (!byte.TryParse(Console.ReadLine(), out status) || (status > 2))
          Console.Write($"\t\t{"Invalid! Status Employee",-16}: ");

        InfoEmployee.Status = (Enumerations.EnStatus)status;

        try
        {

          if (InfoEmployee.SaveModeEmployees())
          {
            _ShowSccessMessageAndShowInformationEmployee(InfoEmployee, "✅ EMPLOYEE UPDATED");
          }

        }
        catch (SqlException SEX)
        {
          _ShowNotFoundMessage($"{SEX.Message}", "❌ NOT FOUND", "Employee could not be found.");
        }
      }
    }

    private static void _DeleteEmployee()
    {
      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║            🗑️ DELETE EMPLOYEE             ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n");

      Console.Write("\n\t\tEnter Employee ID to delete: ");

      int EmployeeID = 0;

      while (!int.TryParse(Console.ReadLine(), out EmployeeID))
        System.Console.WriteLine("\n\t\tInvalid!! Employee ID");


      EmployeesBL InfoEmployee = EmployeesBL.FindEmployeeBy(EmployeeID);

      if (InfoEmployee is null)
        _ShowNotFoundMessage($"Employee with ID {EmployeeID} was not found.", "❌ NOT FOUND", "Employee could not be found.");
      else
      {

        EmployeesBL CopyInfoEmployee = InfoEmployee;

        _GetEmployeeBy(EmployeeID);
        System.Console.WriteLine("\n\n");

        Console.Write("\t\tAre you sure you want to delete this employee?\n");
        System.Console.Write("\t\t(Y = Yes, N = No)\n");
        System.Console.Write("\t\tChoice: ");

        char choice = 'N';

        while (!char.TryParse(Console.ReadLine(), out choice))
          System.Console.Write("\t\tInvalid!! Choice");

        if (char.ToLower(choice) == 'y')
        {
          try
          {
            if (EmployeesBL.DeleteEmployee(EmployeeID))
            {
              string FullNameManager = string.Join(" ", CopyInfoEmployee.FirstName, CopyInfoEmployee.LastName);

              Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
              Console.WriteLine("\t\t║          ✅ EMPLOYEE DELETED             ║");
              Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
              Console.WriteLine($"\t\t║ Employee ID : {CopyInfoEmployee.ID,-27} ║");
              Console.WriteLine($"\t\t║ Name        : {FullNameManager,-27}║");
              Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

            }
          }
          catch
          {
            _ShowNotFoundMessage($"Employee with ID {EmployeeID} was not found.", "❌ ERROR", "Employee could not be found. ");
          }


        }
        else
        {
          Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
          Console.WriteLine("\t\t║          ℹ️ DELETE CANCELLED              ║");
          Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
          Console.WriteLine("\t\t║ No changes were made.                    ║");
          Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
        }
      }


    }

    private static void _SearchEmployee()
    {
      while (true)
      {
        Console.Clear();

        Console.WriteLine("\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine("\t\t║             🔍 SEARCH EMPLOYEES          ║");
        Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

        Console.WriteLine();
        Console.WriteLine("\t\tSearch by:\n\n");
        Console.WriteLine("\t\t1. Name");
        Console.WriteLine("\t\t2. Department");
        Console.WriteLine("\t\t3. Job Title");
        Console.WriteLine("\t\t4. Status");

        Console.WriteLine("\t\t0. Back\n\n");

        Console.Write("\t\tSelect: ");
        byte Choice = 0;

        while (!byte.TryParse(Console.ReadLine(), out Choice) || Choice > 4)
          System.Console.Write("\t\tInvalid!! Choice Search Employee");


        Enumerations.EnChoicesSearchEmployees ChoiceSearchEmployee = (Enumerations.EnChoicesSearchEmployees)Choice;

        switch (ChoiceSearchEmployee)
        {
          case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_FULL_NAME:
            {

              System.Console.Write("\n\n\t\tEnter Full Name : ");
              string? FullName = Console.ReadLine()!;

              _EmployeesList(FullName);
              break;
            }

          case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_DEPARTMENT_NAME:
            {

              System.Console.Write("\n\n\t\tEnter Department Name : ");
              string? DepartmentName = Console.ReadLine()!;

              _EmployeesList(null, DepartmentName);

              break;
            }

          case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_JOB_TITLE:
            {

              System.Console.Write("\n\n\t\tEnter Job Title : ");
              string? JobTitle = Console.ReadLine()!;

              _EmployeesList(null, null, JobTitle);

              break;
            }

          case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_STATUS:
            {

              Console.Write($"\n\t\t{"Enter Status(Active:1 , Inactive:0 , Suspended:2)",-16}: ");

              byte status = 0;
              while (!byte.TryParse(Console.ReadLine(), out status) || status > 2)
                System.Console.Write("\t\tInvalid!! Status Employee");


              _EmployeesList(null, null, null, _GetStatusEmployee((Enumerations.EnStatus)status));

              break;
            }

          case Enumerations.EnChoicesSearchEmployees._kBACK_MAIN_MENU_EMPLOYEES:
            {
              StartupEmployeesModule();
              break;
            }
        }

        System.Console.WriteLine("\n\n\t\tPress any key to continue...");
        Console.ReadKey();
      }

    }

    private static void _DepartmentSammary()
    {
      Console.Clear();

      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║         📊 DEPARTMENT SUMMARY            ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

      System.Console.WriteLine($"\n\n\t\t{"Department",-25} {"Employees",-15} {"Avg Salary",-20}");
      System.Console.WriteLine("\t\t" + new string('-', 55));

      DataTable DT_DepartmentSummary = EmployeesBL.GetDepartmentSammary();
      int CountEmployees = 0;

      foreach (DataRow DR in DT_DepartmentSummary.Rows)
      {

        CountEmployees += Convert.ToInt32(DR["TotalEmployees"]);

        System.Console.WriteLine($"\t\t{DR["DepartmentName"].ToString(),-25} {Convert.ToInt32(DR["TotalEmployees"]).ToString(),-15} {(Convert.ToDouble(DR["Avg Salary"])).ToString("C2"),-20}");


      }

      System.Console.WriteLine("\t\t" + new string('-', 55));
      System.Console.WriteLine("\n\n");


      System.Console.WriteLine($"\t\tTotal Employees: {CountEmployees}\n\n");



    }

    private static void _SalarySummary()
    {
      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║            💰 SALARY SUMMARY             ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n\n");

      DataTable DT_SalarySummary = EmployeesBL.GetSalarySummary();

      if (DT_SalarySummary.Rows.Count > 0)
      {
        DataRow DR_SalarySummary = DT_SalarySummary.Rows[0];

        System.Console.WriteLine($"\t\tMinimum Salary : {Convert.ToDouble(DR_SalarySummary["MinimumSalary"]).ToString("C2")}");
        System.Console.WriteLine($"\t\tMaximum Salary : {Convert.ToDouble(DR_SalarySummary["MaximumSalary"]).ToString("C2")}");
        System.Console.WriteLine($"\t\tAverage Salary : {Convert.ToDouble(DR_SalarySummary["AverageSalary"]).ToString("C2")}");
        System.Console.WriteLine($"\t\tTotal Salary   : {Convert.ToDouble(DR_SalarySummary["TotalSalary"]).ToString("C2")}");
      }
      else
      {
        Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine("\t\t║             ❌ NO SALARY DATA            ║");
        Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
        Console.WriteLine("\t\t║ No salary data is available.             ║");
        Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
      }
    }

    private static void _EmployeesReport()
    {


      while (true)
      {
        Console.Clear();

        Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine("\t\t║             📊 EMPLOYEE REPORT           ║");
        Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
        Console.WriteLine("\t\t║                                          ║");
        Console.WriteLine("\t\t║ 1. Department Summary                    ║");
        Console.WriteLine("\t\t║ 2. Salary Summary                        ║");
        Console.WriteLine("\t\t║ 3. Employee Status Summary               ║");
        Console.WriteLine("\t\t║ 4. Hiring Summary                        ║");
        Console.WriteLine("\t\t║                                          ║");
        Console.WriteLine("\t\t║ 0. 🔙 Back                               ║");
        Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

        Console.Write("\n\n\t\tSelect: ");
        byte Choice = 0;


        while (!byte.TryParse(Console.ReadLine(), out Choice) || (Choice > 4))
          System.Console.Write("\t\tInvalid Choice : ");

        switch ((Enumerations.EnChoicesEmployeesReport)Choice)
        {
          case Enumerations.EnChoicesEmployeesReport._kDEPARTMENT_SUMMARY:
            {
              _DepartmentSammary();
              break;
            }

          case Enumerations.EnChoicesEmployeesReport._kSALARY_SUMMARY:
            {
              _SalarySummary();
              break;
            }

          case Enumerations.EnChoicesEmployeesReport._kBACK:
            {
              StartupEmployeesModule();
              break;
            }
        }

        System.Console.WriteLine("\n\n\t\tPress any key to continue...");
        Console.ReadKey();
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
              Console.WriteLine("\n\t\t╚══════════════════════════════════════════╝\n\n");
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

          case Enumerations.EnCategoriesEmployees._kDELETE_EMPLOYEE:
            {
              _DeleteEmployee();
              break;
            }

          case Enumerations.EnCategoriesEmployees._kSEARCH_EMPLOYEES:
            {
              _SearchEmployee();
              break;
            }

          case Enumerations.EnCategoriesEmployees._kEMPLOYEE_REPORT:
            {
              _EmployeesReport();
              break;
            }
        }

        System.Console.WriteLine("\n\n\t\tPress any key to continue...");
        Console.ReadKey();

      }
    }


  }

}