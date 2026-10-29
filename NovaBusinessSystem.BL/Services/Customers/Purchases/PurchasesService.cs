using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.BL.Services;

public class PurchasesService : IPurchasesService
{


    private readonly IPurchasesRepository _repository;

    public PurchasesService(IPurchasesRepository purchasesRepository)
    {
        this._repository = purchasesRepository ?? throw new ArgumentNullException(nameof(purchasesRepository));
    }

    public Task<IEnumerable<FavoriteProductDto>> GetCustomerFavoriteProductsAsync(int customerId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerId);

        return _repository.GetCustomerFavoriteProductsAsync(customerId);

    }

    public Task<IEnumerable<MonthlyPurchaseSummaryDto>> GetCustomerMonthlyPurchasesAsync()
    {
        return _repository.GetCustomerMonthlyPurchasesAsync();
    }

    public Task<CustomerSpendingSummaryDto?> GetCustomerSpendingAsync(int customerId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerId);

        return _repository.GetCustomerSpendingAsync(customerId);
    }

    public Task<IEnumerable<CustomerRankingDto>> GetCustomersRankingAsync()
    {
        return _repository.GetCustomersRankingAsync();
    }

    public Task<IEnumerable<CustomerPurchaseDto>> GetPurchaseHistoryAsync(int customerId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerId);

        return _repository.GetPurchaseHistoryAsync(customerId);
    }
}