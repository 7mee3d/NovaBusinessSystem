
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

        public Task<IEnumerable<StockLevelReportDTO>>  GetStockLevelReportsAsync() 
        => _reportsDAL.GetStockLevelReportsAsync(); 

         public Task<IEnumerable<InventoryValuationDTO>>  GetInventoryValuationsAsync() 
        => _reportsDAL.GetInventoryValuationsAsync(); 
    }
}