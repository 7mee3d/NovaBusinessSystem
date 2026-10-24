
using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.DAL.Products.Reports
{

    public interface IReportsDAL
    {
        Task<IEnumerable<ProductStatusSummaryDTO>> GetProductStatusSummariesAsync();
}
 
}