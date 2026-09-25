using NovaBusinessSystem.DAL;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.BL
{

    public class LoyaltyBL
    {
        public static async Task<CustomerPointsDTO>? ViewCustomerPointsAsync(int id)
         => await LoyaltyDAL.ViewCustomerPoints(id)!;

        public static async Task<bool> AddPointsToCustomerAsync(int id, int pointsToAdd)
        => await LoyaltyDAL.AddPointsToCustomer(id, pointsToAdd)!;

        public static async Task<bool> RedeemPointsToCustomerAsync(int id, int loyaltyPointsint, int pointsToRedeem)
        {
            if (pointsToRedeem > loyaltyPointsint)
                throw new Exception("INSUFFICIENT POINTS");

            return await LoyaltyDAL.RedeemPointsToCustomer(id, pointsToRedeem)!;
        }

        public static async Task<IEnumerable<TopLoyaltyCustomerDTO>>? GetTopLoyaltyCustomersAsync()
        => await LoyaltyDAL.GetTopLoyaltyCustomers()!;

        public static async Task<LoyaltyStatisticsDTO>? GetLoyaltyStatisticsAsync()
        => await LoyaltyDAL.GetLoyaltyStatistics()!;
    }
}