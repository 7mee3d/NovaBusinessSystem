using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.DAL.Customers.Purchases;

namespace NovaBusinessSystem.BL.Customers.Purchases
{

    public class PurchasesBL
    {
        public static async Task<IEnumerable<CustomerPurchaseDTO>> GetPurchaseHistoryAsync(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await PurchasesDAL.GetPurchaseHistoryAsync(customerID);
        }

        public static async Task<CustomerSpendingSummaryDTO>? GetCustomerSpendingAsync(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await PurchasesDAL.GetCustomerSpendingAsync(customerID)!;
        }

        public static async Task<IEnumerable<FavoriteProductDTO>> GetCustomerFavoriteProductsAsync(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await PurchasesDAL.GetCustomerFavoriteProductsAsync(customerID)!;
        }

        public static async Task<IEnumerable<MonthlyPurchaseDTO>> GetCustomerMonthlyPurchasesAsync()
        {
            return await PurchasesDAL.GetCustomerMonthlyPurchasesAsync()!;
        }
        public static async Task<IEnumerable<CustomerRankingDTO>> GetCustomersRankingAsync()
        {
            return await PurchasesDAL.GetGetCustomersRankingAsync()!;
        }
    }
}