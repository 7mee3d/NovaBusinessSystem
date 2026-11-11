
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
}