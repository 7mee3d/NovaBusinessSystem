
using NovaBusinessSystem.DTOs.Suppliers;

namespace NovaBusinessSystem.BL.Interfaces;

public interface ISuppliersRepository
{
    Task<SupplierListResponseDTO> GetSupplierListAsync (SupplierListRequestDTO supplier) ;
     
}