namespace NovaBusinessSystem.DTOs.Suppliers;

public record SupplierListItemResponseDTO(
    int SupplierID,
    string SupplierName,
    string? City,
    int Orders,
    string Status
);