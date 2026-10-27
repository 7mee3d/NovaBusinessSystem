
using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.DAL.Products.Reports
{

    public interface IReportsDAL
    {
        Task<IEnumerable<ProductStatusSummaryDTO>> GetProductStatusSummariesAsync();
        Task<IEnumerable<ProductsByCategoryDTO>> GetProductByCategoriesAsync();
        Task<IEnumerable<StockLevelReportDTO>> GetStockLevelReportsAsync();
        Task<IEnumerable<InventoryValuationDTO>> GetInventoryValuationsAsync();
        Task<IEnumerable<SalesPerformanceReportDTO>> GetSalesPerformanceReportsAsync();
        Task<IEnumerable<CategoryRevenueReportDTO>> GetCategoryRevenueReportsAsync();
        Task<IEnumerable<TopSellingProductDTO>> GetTopSellingProductsAsync(int rank);
        Task<IEnumerable<SlowMovingProductDTO>> GetSlowMovingProductsAsync (int maximumUnitsSold);

    }

}