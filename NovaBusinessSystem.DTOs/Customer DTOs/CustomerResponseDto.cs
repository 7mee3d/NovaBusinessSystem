namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerResponseDto(
    int CustomerID,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string City,
    DateTime RegistrationDate,
    int LoyaltyPoints,
    string Status
);