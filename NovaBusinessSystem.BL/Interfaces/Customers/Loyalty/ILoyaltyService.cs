
using NovaBusinessSystem.DTOs.Customers;
using NovaBusinessSystem.DTOs.Customers.Loyalty;

namespace NovaBusinessSystem.BL.Interfaces;

public interface ILoyaltyService
{
    Task<CustomerPointsDto?> GetCustomerPointsAsync(int customerID);
    Task<bool> AddPointsAsync(int customerID, int pointsToAdd);
    Task<bool> RedeemPointsAsync(int customerID, int pointsToRedeem);
    Task<IEnumerable<TopLoyaltyCustomerDto>> GetTopLoyaltyCustomersAsync();
    Task<LoyaltyStatisticsDto?> GetLoyaltyStatisticsAsync();
}
