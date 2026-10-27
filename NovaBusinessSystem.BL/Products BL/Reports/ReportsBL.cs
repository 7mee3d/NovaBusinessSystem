
using NovaBusinessSystem.DAL.Products.Reports;
using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.BL.Products.Reports
{

    public class ReportsBL
    {

        private readonly IReportsDAL _reportsDAL;

        public ReportsBL(IReportsDAL reportsDAL)
        {
            this._reportsDAL = reportsDAL;
        }

        public Task<IEnumerable<ProductStatusSummaryDTO>> GetProductStatusSummariesAsync()
        {
            return _reportsDAL.GetProductStatusSummariesAsync();
        }

        public Task<IEnumerable<ProductsByCategoryDTO>> GetProductByCategoriesAsync()
        => _reportsDAL.GetProductByCategoriesAsync();

        public Task<IEnumerable<StockLevelReportDTO>> GetStockLevelReportsAsync()
        => _reportsDAL.GetStockLevelReportsAsync();

        public Task<IEnumerable<InventoryValuationDTO>> GetInventoryValuationsAsync()
        => _reportsDAL.GetInventoryValuationsAsync();

        public Task<IEnumerable<SalesPerformanceReportDTO>> GetSalesPerformanceReportsAsync()
        => _reportsDAL.GetSalesPerformanceReportsAsync();

        public Task<IEnumerable<CategoryRevenueReportDTO>> GetCategoryRevenueReportsAsync()
        => _reportsDAL.GetCategoryRevenueReportsAsync();

        public Task<IEnumerable<TopSellingProductDTO>> GetTopSellingProductsAsync(int rank)
        {
            if (rank <= 0)
                throw new ArgumentOutOfRangeException($"The rank {rank} out of range");

            return _reportsDAL.GetTopSellingProductsAsync(rank);
        }

        public Task<IEnumerable<SlowMovingProductDTO>> GetSlowMovingProductsAsync(
            int maximumUnitsSold)
        {
            {
                if (maximumUnitsSold <= 0)
                    throw new ArgumentOutOfRangeException($"The {nameof(maximumUnitsSold)} is not valid");

                return _reportsDAL.GetSlowMovingProductsAsync(maximumUnitsSold);
            }
        }

        public Task<IEnumerable<UnsoldProductDTO>> GetUnsoldProductsAsync()
        => _reportsDAL.GetUnsoldProductsAsync();



    }
}