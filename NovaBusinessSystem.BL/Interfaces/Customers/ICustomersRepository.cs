using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.DTOs.Customers;
using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Interfaces;

public interface ICustomersRepository
{

    Task<IEnumerable<CustomerResponseDto>> GetAllAsync();
    Task<CustomerResponseDto?> GetByIdAsync(int CustomerID);
    Task<int> AddAsync(CustomerCreateRequestDto customerDTO);
    Task<int> UpdateAsync(int customerID, CustomerCreateRequestDto customer);
    Task<bool> DeleteAsync(int customerID);
    Task<bool> IsEmailExistsAsync(int id, string email);
}
