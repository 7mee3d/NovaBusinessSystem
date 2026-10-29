namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerPurchaseDto(
    int SaleID,
    DateTime SaleDate,
    decimal TotalAmount,
    string PaymentMethod,
    string Status
);