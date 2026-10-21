using NovaBusinessSystem.DAL.Products.Sales;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.BL.Products.Sales
{

    public class Sales
    {

        public static async Task<IEnumerable<ProductSalesHistoryDTO>> GetProductSalesHistoriesAsync(int productID)
        {

            if (productID <= 0)
                throw new ArgumentOutOfRangeException($"The product id = {productID} out of range");

            return await SalesDAL.GetProductSalesHistoriesAsync(productID);
        }

        public static async Task<IEnumerable<ProductSalesSummaryDTO>> ProductSalesSummariesAsync(int productID)
        {
            if (productID <= 0)
                throw new ArgumentOutOfRangeException($"The product id = {productID} out of range");

            return await SalesDAL.GetProductSalesSummariesAsync(productID);
        }

        public static async Task<IEnumerable<TopSellingProductDTO>> TopSellingProductsAsync(int rank)
        {
            if (rank <= 0)
                throw new ArgumentOutOfRangeException($"The rank = {rank} out of range");

            return await SalesDAL.GetTopSellingProductsAsync(rank);
        }

        public static async Task<IEnumerable<LeastSellingProductDTO>> GetLeastSellingProductsAsync(int rank)
        {
            if (rank <= 0)
                throw new ArgumentOutOfRangeException($"The rank = {rank} out of range");

            return await SalesDAL.GetLeastSellingProductsAsync(rank);
        }

        public static async Task<IEnumerable<ProductRevenueRankingDTO>> GetProductRevenueRankingsAsync(int rank)
        {
            if (rank <= 0)
                throw new ArgumentOutOfRangeException($"The rank = {rank} out of range");

            return await SalesDAL.GetProductRevenueRankingsAsync(rank);
        }

        public static async Task<IEnumerable<MonthlyProductSalesDTO>> GetMonthlyProductSalesAsync(int productID)
        {
            if (productID <= 0)
                throw new ArgumentOutOfRangeException($"The product id = {productID} out of range");

            return await SalesDAL.GetMonthlyProductSalesAsync(productID);
        }

        public static async Task<IEnumerable<CategoryPerformanceDTO>> GetCategoryPerformancesAsync () => await SalesDAL.GetCategoryPerformancesAsync ();
    }
}