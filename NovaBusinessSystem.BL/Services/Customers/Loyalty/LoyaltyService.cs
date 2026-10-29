using System.Drawing;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers.Loyalty;

namespace NovaBusinessSystem.BL.Services;

public class LoyaltyService : ILoyaltyService
{

    private readonly ILoyaltyRepository _repository;

    public LoyaltyService(ILoyaltyRepository loyaltyRepository)
    {
        this._repository = loyaltyRepository ?? throw new ArgumentNullException(nameof(loyaltyRepository));
    }

    public Task<bool> AddPointsAsync(int customerID, int pointsToAdd)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerID);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pointsToAdd);

        return _repository.AddPointsAsync(customerID, pointsToAdd);
    }

    public Task<CustomerPointsDto?> GetCustomerPointsAsync(int customerID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerID);
        return _repository.GetCustomerPointsAsync(customerID);

    }

    public Task<LoyaltyStatisticsDto?> GetLoyaltyStatisticsAsync()
    {
        return _repository.GetLoyaltyStatisticsAsync();
    }

    public Task<IEnumerable<TopLoyaltyCustomerDto>> GetTopLoyaltyCustomersAsync()
    {
        return _repository.GetTopLoyaltyCustomersAsync();
    }

    public Task<bool> RedeemPointsAsync(int customerID, int pointsToRedeem)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerID);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pointsToRedeem);

        return _repository.RedeemPointsAsync(customerID, pointsToRedeem);

    }
}