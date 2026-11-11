namespace NovaBusinessSystem.DTOs.Suppliers;

public record SupplierDetailsResponseDTO(
    SupplierDetailsDTO Supplier,
    SupplierProcurementSummaryDTO ProcurementSummary
);