namespace NovaBusinessSystem.DTOs.Suppliers;

public record DeleteSupplierResponseDto(
    int SupplierID,
    string Action,
    string Message
);