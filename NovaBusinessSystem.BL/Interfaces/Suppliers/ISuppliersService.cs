using NovaBusinessSystem.DTOs.Suppliers;

namespace NovaBusinessSystem.BL.Interfaces;

public interface ISuppliersService
{
    Task<SupplierListResponseDTO> GetSupplierListAsync(SupplierListRequestDTO supplier);

}