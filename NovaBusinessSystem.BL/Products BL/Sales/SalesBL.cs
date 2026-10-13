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
    }
}