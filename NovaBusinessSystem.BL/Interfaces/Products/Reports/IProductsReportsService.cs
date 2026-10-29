using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IProductsReportsService
{
    Task<IEnumerable<ProductStatusSummaryReportDto>> GetProductStatusSummariesAsync();
    Task<IEnumerable<ProductsByCategoryReportDto>> GetProductByCategoriesAsync();
    Task<IEnumerable<StockLevelReportDto>> GetStockLevelReportsAsync();
    Task<IEnumerable<InventoryValuationReportDto>> GetInventoryValuationsAsync();
    Task<IEnumerable<SalesPerformanceReportDto>> GetSalesPerformanceReportsAsync();
    Task<IEnumerable<CategoryRevenueReportDto>> GetCategoryRevenueReportsAsync();
    Task<IEnumerable<TopSellingProductReportDto>> GetTopSellingProductsAsync(int rank);
    Task<IEnumerable<SlowMovingProductReportDto>> GetSlowMovingProductsAsync(int maximumUnitsSold);
    Task<IEnumerable<UnsoldProductReportDto>> GetUnsoldProductsAsync();
    Task<IEnumerable<MonthlyProductPerformanceReportDto>> GetMonthlyProductPerformanceAsync();
}