namespace NovaBusinessSystem.DTOs.Suppliers;

public record SupplierListRequestDTO(
    string? Search = null,
    string? Status = null,
    string SortBy = "SupplierName",
    string SortDirection = "ASC",
    int PageNumber = 1,
    int PageSize = 10
);