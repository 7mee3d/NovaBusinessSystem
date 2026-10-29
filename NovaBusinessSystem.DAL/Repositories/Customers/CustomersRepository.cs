using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.DAL.Repositories;

public class CustomersRepository : ICustomersRepository
{
    public async Task<IEnumerable<CustomerResponseDto>> GetAllAsync()
    {
        List<CustomerResponseDto> customers = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomers]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int customerIDOrdinal = reader.GetOrdinal("CustomerID");
        int firstNameOrdinal = reader.GetOrdinal("FirstName");
        int lastNameOrdinal = reader.GetOrdinal("LastName");
        int emailOrdinal = reader.GetOrdinal("Email");
        int phoneOrdinal = reader.GetOrdinal("Phone");
        int cityOrdinal = reader.GetOrdinal("City");
        int registrationDateOrdinal = reader.GetOrdinal("RegistrationDate");
        int loyaltyPointsOrdinal = reader.GetOrdinal("LoyaltyPoints");
        int statusOrdinal = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            customers.Add(new CustomerResponseDto(
                reader.GetInt32(customerIDOrdinal),
                reader.GetString(firstNameOrdinal),
                reader.GetString(lastNameOrdinal),
                reader.GetString(emailOrdinal),
                reader.GetString(phoneOrdinal),
                reader.GetString(cityOrdinal),
                reader.GetDateTime(registrationDateOrdinal),
                reader.GetInt32(loyaltyPointsOrdinal),
                reader.GetString(statusOrdinal)
            ));
        }

        return customers;
    }

    public async Task<CustomerResponseDto?> GetByIdAsync(int customerID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomerByID]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ID", SqlDbType.Int).Value = customerID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int firstNameOrdinal = reader.GetOrdinal("FirstName");
        int lastNameOrdinal = reader.GetOrdinal("LastName");
        int emailOrdinal = reader.GetOrdinal("Email");
        int phoneOrdinal = reader.GetOrdinal("Phone");
        int cityOrdinal = reader.GetOrdinal("City");
        int registrationDateOrdinal = reader.GetOrdinal("RegistrationDate");
        int loyaltyPointsOrdinal = reader.GetOrdinal("LoyaltyPoints");
        int statusOrdinal = reader.GetOrdinal("Status");

        return new CustomerResponseDto(
            customerID,
            reader.GetString(firstNameOrdinal),
            reader.GetString(lastNameOrdinal),
            reader.GetString(emailOrdinal),
            reader.GetString(phoneOrdinal),
            reader.GetString(cityOrdinal),
            reader.GetDateTime(registrationDateOrdinal),
            reader.GetInt32(loyaltyPointsOrdinal),
            reader.GetString(statusOrdinal)
        );
    }

    public async Task<int> AddAsync(CustomerCreateRequestDto customer)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_AddNewCustomer]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = customer.FirstName;
        command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = customer.LastName;
        command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = customer.Email;
        command.Parameters.Add("@Phone", SqlDbType.NVarChar, 11).Value = customer.Phone.Trim();
        command.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = customer.City;
        command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = customer.Status;

        var customerIDParameter = new SqlParameter("@CustomerID", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        command.Parameters.Add(customerIDParameter);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();

        return Convert.ToInt32(customerIDParameter.Value);
    }

    public async Task<bool> IsEmailExistsAsync(int id, string email)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_IsEmailExists]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;
        command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

    public async Task<int> UpdateAsync(int customerID, CustomerCreateRequestDto customer)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_UpdateCustomer]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = customer.FirstName;
        command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = customer.LastName;
        command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = customer.Email;
        command.Parameters.Add("@Phone", SqlDbType.NVarChar, 11).Value = customer.Phone;
        command.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = customer.City;
        command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = customer.Status;
        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result);
    }

    public async Task<bool> DeleteAsync(int customerID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_DeleteCustomer]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

}