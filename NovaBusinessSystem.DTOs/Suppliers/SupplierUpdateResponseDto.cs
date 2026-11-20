
namespace NovaBusinessSystem.DTOs.Suppliers;

public record SupplierUpdateResponseDto(
    int SupplierID,
    string SupplierName,
    string Status,
    DateTime UpdatedAt
);
