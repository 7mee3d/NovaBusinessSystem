using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.BL.Services;

public class ProductsReportsService : IProductsReportsService
{
    private readonly IProductsReportsRepository _repository;
    public ProductsReportsService(IProductsReportsRepository productsReportsRepository)
    {
        this._repository = productsReportsRepository ?? throw new ArgumentNullException(nameof(productsReportsRepository));
    }

    public Task<IEnumerable<CategoryRevenueReportDto>> GetCategoryRevenueReportsAsync()
    {

        return this._repository.GetCategoryRevenueReportsAsync();
    }

    public Task<IEnumerable<InventoryValuationReportDto>> GetInventoryValuationsAsync()
    {
        return this._repository.GetInventoryValuationsAsync();
    }

    public Task<IEnumerable<MonthlyProductPerformanceReportDto>> GetMonthlyProductPerformanceAsync()
    {
        return this._repository.GetMonthlyProductPerformanceAsync();
    }

    public Task<IEnumerable<ProductsByCategoryReportDto>> GetProductByCategoriesAsync()
    {
        return this._repository.GetProductByCategoriesAsync();
    }

    public Task<IEnumerable<ProductStatusSummaryReportDto>> GetProductStatusSummariesAsync()
    {
        return this._repository.GetProductStatusSummariesAsync();
    }

    public Task<IEnumerable<SalesPerformanceReportDto>> GetSalesPerformanceReportsAsync()
    {
        return this._repository.GetSalesPerformanceReportsAsync();
    }

    public Task<IEnumerable<SlowMovingProductReportDto>> GetSlowMovingProductsAsync(int maximumUnitsSold)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maximumUnitsSold);

        return this._repository.GetSlowMovingProductsAsync(maximumUnitsSold);
    }

    public Task<IEnumerable<StockLevelReportDto>> GetStockLevelReportsAsync()
    {
        return this._repository.GetStockLevelReportsAsync();
    }

    public Task<IEnumerable<TopSellingProductReportDto>> GetTopSellingProductsAsync(int rank)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rank);

        return this._repository.GetTopSellingProductsAsync(rank);
    }

    public Task<IEnumerable<UnsoldProductReportDto>> GetUnsoldProductsAsync()
    {
        return this._repository.GetUnsoldProductsAsync();
    }
}