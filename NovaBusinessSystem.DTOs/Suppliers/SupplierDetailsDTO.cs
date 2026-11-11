namespace NovaBusinessSystem.DTOs.Suppliers ; 

public record SupplierDetailsDTO(
    int SupplierID,
    string SupplierName,
    string? ContactName,
    string? Email,
    string? Phone,
    string? City,
    string? Country,
    string PaymentTerms,
    string Status
);