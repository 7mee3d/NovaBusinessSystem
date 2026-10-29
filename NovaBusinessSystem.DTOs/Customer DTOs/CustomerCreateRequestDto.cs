namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerCreateRequestDto(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string City,
    string Status
);