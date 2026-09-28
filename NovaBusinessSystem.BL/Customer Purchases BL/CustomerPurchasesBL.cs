using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.DAL;

namespace NovaBusinessSystem.BL
{

    public class CustomerPurchasesBL
    {
        public static async Task<IEnumerable<CustomerPurchaseDTO>> GetPurchaseHistoryAsync(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await CustomerPurchasesDAL.GetPurchaseHistoryAsync(customerID);
        }

        public static async Task<CustomerSpendingSummaryDTO>? GetCustomerSpendingAsync(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await CustomerPurchasesDAL.GetCustomerSpendingAsync(customerID)!;
        }

        public static async Task<IEnumerable<FavoriteProductDTO>> GetCustomerFavoriteProductsAsync(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await CustomerPurchasesDAL.GetCustomerFavoriteProductsAsync(customerID)!;
        }

        public static async Task<IEnumerable<MonthlyPurchaseDTO>> GetCustomerMonthlyPurchasesAsync()
        {
            return await CustomerPurchasesDAL.GetCustomerMonthlyPurchasesAsync()!;
        }
        public static async Task<IEnumerable<CustomerRankingDTO>> GetCustomersRankingAsync()
        {
            return await CustomerPurchasesDAL.GetGetCustomersRankingAsync()!;
        }
    }
}