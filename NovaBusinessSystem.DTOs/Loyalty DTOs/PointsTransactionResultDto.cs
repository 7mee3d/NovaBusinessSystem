namespace NovaBusinessSystem.DTOs.Customers.Loyalty;
public record PointsTransactionResultDto(
    string CustomerName,
    int PreviousPoints,
    int Points,
    int NewBalance
);