using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.BL.Services;

public class CustomersService : ICustomersService
{

    private readonly ICustomersRepository _repository;

    public CustomersService(ICustomersRepository customersRepository)
    {
        this._repository = customersRepository ?? throw new ArgumentNullException(nameof(customersRepository));
    }

    public Task<int> AddAsync(CustomerCreateRequestDto customerDto)
    {

        ArgumentNullException.ThrowIfNull(customerDto);
        return _repository.AddAsync(customerDto);
    }

    public Task<bool> DeleteAsync(int customerID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerID);
        return _repository.DeleteAsync(customerID);
    }

    public Task<IEnumerable<CustomerResponseDto>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<CustomerResponseDto?> GetByIdAsync(int customerID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerID);

        return _repository.GetByIdAsync(customerID);
    }

    public Task<int> UpdateAsync(int customerID, CustomerCreateRequestDto customer)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerID);
        ArgumentNullException.ThrowIfNull(customer);
        return _repository.UpdateAsync(customerID, customer);
    }

    public Task<bool> IsEmailExistsAsync(int id, string email)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        ArgumentOutOfRangeException.ThrowIfNullOrWhiteSpace(email);
        return _repository.IsEmailExistsAsync(id, email);
    }
}