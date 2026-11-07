namespace NovaBusinessSystem.DTOs.Suppliers;

public record SupplierListResponseDTO(
    List<SupplierListItemResponseDTO> Suppliers,
    int TotalCount,
    int PageNumber,
    int PageSize,
    int TotalPages
);