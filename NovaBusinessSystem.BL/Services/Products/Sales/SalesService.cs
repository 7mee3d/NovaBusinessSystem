using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.BL.Services;

public class SalesService : ISalesService
{

    private readonly ISalesRepository _repository;

    public SalesService(ISalesRepository salesRepository)
    {
        this._repository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
    }

    public Task<IEnumerable<CategoryPerformanceDto>> GetCategoryPerformancesAsync()
    {
        return _repository.GetCategoryPerformancesAsync();
    }

    public Task<IEnumerable<LeastSellingProductDto>> GetLeastSellingProductsAsync(int rank)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rank);

        return _repository.GetLeastSellingProductsAsync(rank);
    }

    public Task<IEnumerable<MonthlyProductSalesDto>> GetMonthlyProductSalesAsync(int productID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);

        return _repository.GetMonthlyProductSalesAsync(productID);
    }

    public Task<ProductCustomerSalesDto?> GetProductCustomerSalesAsync(int productID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);

        return _repository.GetProductCustomerSalesAsync(productID);
    }

    public Task<IEnumerable<ProductRevenueRankingDto>> GetProductRevenueRankingsAsync(int rank)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rank);

        return _repository.GetProductRevenueRankingsAsync(rank);
    }

    public Task<IEnumerable<ProductSalesHistoryDto>> GetProductSalesHistoriesAsync(int productID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);

        return _repository.GetProductSalesHistoriesAsync(productID);
    }

    public Task<IEnumerable<ProductSalesSummaryDto>> GetProductSalesSummariesAsync(int productID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);

        return _repository.GetProductSalesSummariesAsync(productID);
    }

    public Task<IEnumerable<TopSellingProductDto>> GetTopSellingProductsAsync(int rank)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rank);

        return _repository.GetTopSellingProductsAsync(rank);
    }
}