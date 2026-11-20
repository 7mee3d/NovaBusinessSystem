
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Suppliers;

namespace NovaBusinessSystem.BL.Services;


public class SuppliersService : ISuppliersService
{

    private readonly ISuppliersRepository _repository;

    public SuppliersService(ISuppliersRepository suppliersRepository)
    {
        this._repository = suppliersRepository ?? throw new ArgumentNullException(nameof(suppliersRepository));
    }

    public Task<SupplierCreateResponseDto?> CreateSupplierAsync(SupplierCreateRequestDto supplierRequest)
    {
        ArgumentNullException.ThrowIfNull(supplierRequest);

        return _repository.CreateSupplierAsync(supplierRequest);
    }

    public Task<SupplierDetailsResponseDTO?> GetSupplierDetailsResponseAsync(int supplierID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(supplierID);

        return _repository.GetSupplierDetailsResponseAsync(supplierID);
    }

    public Task<SupplierListResponseDTO> GetSupplierListAsync(SupplierListRequestDTO supplier)
    {
        ArgumentNullException.ThrowIfNull(supplier);

        return _repository.GetSupplierListAsync(supplier);
    }

    public Task<SupplierUpdateResponseDto?> UpdateSupplier(int supplierID, SupplierUpdateRequestDto supplierUpdate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(supplierID);

        ArgumentNullException.ThrowIfNull(supplierUpdate);


        return _repository.UpdateSupplier(supplierID, supplierUpdate);

    }

    public  Task<DeleteSupplierResponseDto?> DeleteSupplierAsync(int supplierID)
    {
        if (supplierID <= 0)
            throw new ArgumentException("Invalid supplier ID.");

        return  _repository.DeleteSupplierAsync(supplierID);
    }
}