
namespace NovaBusinessSystem.DTOs.Products.Sales
{
    public record ProductCustomerSalesDTO(
        string ProductName,
        int UniqueCustomers,
        int TotalOrders,
        int UnitsSold,
        string TopCustomer,
        int UnitsPurchased,
        decimal AmountSpent
    );
}
