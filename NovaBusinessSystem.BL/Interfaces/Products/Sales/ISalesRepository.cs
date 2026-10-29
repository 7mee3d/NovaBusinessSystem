using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.BL.Interfaces;

public interface ISalesRepository
{

    Task<IEnumerable<ProductSalesHistoryDto>> GetProductSalesHistoriesAsync(int productID);
    Task<IEnumerable<ProductSalesSummaryDto>> GetProductSalesSummariesAsync(int productID);
    Task<IEnumerable<TopSellingProductDto>> GetTopSellingProductsAsync(int rank);
    Task<IEnumerable<LeastSellingProductDto>> GetLeastSellingProductsAsync(int rank);
    Task<IEnumerable<ProductRevenueRankingDto>> GetProductRevenueRankingsAsync(int rank);
    Task<IEnumerable<MonthlyProductSalesDto>> GetMonthlyProductSalesAsync(int productID);
    Task<IEnumerable<CategoryPerformanceDto>> GetCategoryPerformancesAsync();
    Task<ProductCustomerSalesDto?> GetProductCustomerSalesAsync(int productID);
}