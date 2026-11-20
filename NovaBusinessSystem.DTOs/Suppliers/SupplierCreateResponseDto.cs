
namespace NovaBusinessSystem.DTOs.Suppliers;


public record SupplierCreateResponseDto(

    int SupplierID,
    string SupplierName,
    string ? City,
    int PaymentTerms,
    string Status

);
