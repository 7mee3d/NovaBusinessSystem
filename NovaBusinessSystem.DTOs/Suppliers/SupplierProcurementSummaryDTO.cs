namespace NovaBusinessSystem.DTOs.Suppliers ;


public record SupplierProcurementSummaryDTO(
    int TotalPurchaseOrders,
    int FullyReceivedOrders,
    int OpenOrders,
    int CancelledOrders,
    decimal TotalOrderedValue,
    decimal AcceptedReceivedValue,
    DateTime? LastPurchaseOrderDate
);