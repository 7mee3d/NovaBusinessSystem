
using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.DAL.Products.Reports
{

    public interface IReportsDAL
    {
        Task<IEnumerable<ProductStatusSummaryDTO>> GetProductStatusSummariesAsync();
        Task<IEnumerable<ProductsByCategoryDTO>> GetProductByCategoriesAsync ();   
        Task <IEnumerable<StockLevelReportDTO>> GetStockLevelReportsAsync();
        
}
 
}