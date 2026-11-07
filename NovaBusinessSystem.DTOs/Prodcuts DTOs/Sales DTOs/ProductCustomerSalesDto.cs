namespace NovaBusinessSystem.DTOs.Products.Sales;

public record ProductCustomerSalesDto(
    string ProductName,
    int UniqueCustomers,
    int TotalOrders,
    int UnitsSold,
    string TopCustomer,
    int UnitsPurchased,
    decimal AmountSpent
);