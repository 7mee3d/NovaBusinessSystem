

using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IPurchasesService
{

    Task<IEnumerable<CustomerPurchaseDto>> GetPurchaseHistoryAsync(int customerId);
    Task<CustomerSpendingSummaryDto?> GetCustomerSpendingAsync(int customerId);
    Task<IEnumerable<FavoriteProductDto>> GetCustomerFavoriteProductsAsync(int customerId);
    Task<IEnumerable<MonthlyPurchaseSummaryDto>> GetCustomerMonthlyPurchasesAsync();
    Task<IEnumerable<CustomerRankingDto>> GetCustomersRankingAsync();
}
