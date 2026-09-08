using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class EmployeesDAL
{

    public static DataTable GetListEmployees()
    {

        DataTable DT_AllEmployees = new DataTable();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        {


            using (SqlCommand command = new SqlCommand("[dbo].[usp_ListEmployees]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                // way one useing Data Adapter (DOn't use SqlConnection ) 
                //Way Two using Data Reader (Must declare SqlConnection )

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        DT_AllEmployees.Load(reader);
                }
            }
        }

        return DT_AllEmployees;
    }

    public static bool GetEmployeeBy(
        int employeeID,
        ref string firstName,
        ref string lastName,
        ref int departmentID,
        ref int managerID,
        ref string jobTitle,
        ref decimal salary,
        ref DateTime hireDate,
        ref string phone,
        ref string email,
        ref byte status
    )
    {

        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].[usp_GetEmployeeByID]", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@EmployeeID", employeeID);

            //output parameters 

            SqlParameter paramFirstName = command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 200);
            paramFirstName.Direction = ParameterDirection.Output;

            SqlParameter paramLastName = command.Parameters.Add("@LastName", SqlDbType.NVarChar, 200);
            paramLastName.Direction = ParameterDirection.Output;

            SqlParameter paramDepartmentID = command.Parameters.Add("@DepartmentID", SqlDbType.Int);
            paramDepartmentID.Direction = ParameterDirection.Output;

            SqlParameter paramManagerID = command.Parameters.Add("@ManagerID", SqlDbType.Int);
            paramManagerID.Direction = ParameterDirection.Output;

            SqlParameter paramJobTitle = command.Parameters.Add("@JobTitle", SqlDbType.NChar, 200);
            paramJobTitle.Direction = ParameterDirection.Output;

            SqlParameter paramSalary = command.Parameters.Add("@Salary", SqlDbType.Decimal);
            paramSalary.Precision = 10;
            paramSalary.Scale = 2;
            paramSalary.Direction = ParameterDirection.Output;

            SqlParameter paramHireDate = command.Parameters.Add("@HireDate", SqlDbType.Date);
            paramHireDate.Direction = ParameterDirection.Output;

            SqlParameter paramPhone = command.Parameters.Add("@Phone", SqlDbType.Char, 11);
            paramPhone.Direction = ParameterDirection.Output;

            SqlParameter paramEmail = command.Parameters.Add("@Email", SqlDbType.VarChar, -1);
            paramEmail.Direction = ParameterDirection.Output;

            SqlParameter paramStatus = command.Parameters.Add("@Status", SqlDbType.TinyInt);
            paramStatus.Direction = ParameterDirection.Output;


            try
            {

                connection.Open();

                command.ExecuteNonQuery();


                firstName = (string)paramFirstName.Value;
                lastName = (string)paramLastName.Value;
                departmentID = (int)paramDepartmentID.Value;
                managerID = (int)(paramManagerID.Value ?? -1);
                jobTitle = (string)paramJobTitle.Value;
                salary = (decimal)paramSalary.Value;
                hireDate = (DateTime)paramHireDate.Value;
                phone = (string)paramPhone.Value;
                email = (string)paramEmail.Value;
                status = (byte)paramStatus.Value;

                isFound = true;

            }
            catch (SqlException SEX)
            {

                if (SEX.Number == 50001)
                    isFound = false;
                else
                    throw;

            }
        }

        return isFound;
    }


    public static int AddNewEmployee(
         string firstName,
         string lastName,
         int departmentID,
         int managerID,
         string jobTitle,
         decimal salary,
         string phone,
         string email
    )
    {
        int EmployeeID = -1;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_AddNewEmployee", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = firstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = lastName;
            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
            command.Parameters.Add("@ManagerID", SqlDbType.Int).Value = managerID;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 200).Value = jobTitle;

            SqlParameter paramSalary =
                command.Parameters.Add("@Salary", SqlDbType.Decimal);

            paramSalary.Precision = 10;
            paramSalary.Scale = 2;
            paramSalary.Value = salary;

            command.Parameters.Add("@Phone", SqlDbType.Char, 11).Value = phone;
            command.Parameters.Add("@Email", SqlDbType.VarChar, -1).Value = email;

            SqlParameter paramEmployeeID =
                command.Parameters.Add("@EmployeeID", SqlDbType.Int);

            paramEmployeeID.Direction = ParameterDirection.Output;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                EmployeeID = Convert.ToInt32(paramEmployeeID.Value);
            }
            catch (SqlException SEX)
            {
                if (SEX.Number >= 50001)
                    EmployeeID = -1;

                throw;
            }
        }

        return EmployeeID;
    }


    public static bool UpdateEmployee(
        int EmployeeID,
         string firstName,
         string lastName,
         int departmentID,
         int managerID,
         string jobTitle,
         decimal salary,
         string phone,
         string email ,
         string Status 
    )
    {

        bool IsUpdated = false ;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_UpdateEmployee", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = firstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = lastName;
            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
            command.Parameters.Add("@ManagerID", SqlDbType.Int).Value = managerID;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 200).Value = jobTitle;
            command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = salary;
            command.Parameters.Add("@Phone", SqlDbType.Char, 11).Value = phone;
            command.Parameters.Add("@Email", SqlDbType.VarChar, -1).Value = email;
            command.Parameters.Add("@Status", SqlDbType.VarChar , 20).Value = Status;      


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                IsUpdated = true ; 
            }
            catch (SqlException SEX)
            {
                if (SEX.Number >= 50001)
                    IsUpdated = false ;

                throw;
            }
        }

        return IsUpdated;
    }

    public static bool DeleteEmployee (int EmployeeID)
    {
        
        bool IsDelete = false ;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString)) 
        using (SqlCommand command = new SqlCommand("[dbo].usp_DeleteEmployee" , connection))
        {
            
            command.Parameters.AddWithValue("@EmployeeID" , EmployeeID ) ;

            try
            {
                connection.Open(); 

                command.ExecuteNonQuery(); 

                IsDelete = true ; 
            }catch (SqlException SEX)
            {
                if(SEX.Number >= 50001) 
                    IsDelete = false ;
                
                throw ; 
            }

        
        }

        return IsDelete ; 
    }

}