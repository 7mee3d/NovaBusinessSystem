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

    }
}