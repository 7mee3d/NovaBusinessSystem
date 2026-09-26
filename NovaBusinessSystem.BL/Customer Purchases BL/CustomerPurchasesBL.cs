using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.DAL;

namespace NovaBusinessSystem.BL
{

    public class CustomerPurchasesBL
    {
        public static async Task<IEnumerable<CustomerPurchaseDTO>> GetPurchaseHistory(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await CustomerPurchasesDAL.GetPurchaseHistory(customerID);
        }

        public static async Task<CustomerSpendingSummaryDTO>? GetCustomerSpending(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await CustomerPurchasesDAL.GetCustomerSpending(customerID)!;
        }

        public static async Task<IEnumerable<FavoriteProductDTO>> GetCustomerFavoriteProducts(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await CustomerPurchasesDAL.GetCustomerFavoriteProducts(customerID)!;
        }

    }
}