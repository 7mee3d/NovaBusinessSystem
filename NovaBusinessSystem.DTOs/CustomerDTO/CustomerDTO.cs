namespace NovaBusinessSystem.DTOs;

public class CustomerDTO
{
    public int CustomerID { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public DateTime RegistrationDate { get; private set; }
    public int LoyaltyPoints { get; private set; }
    public string Status { get; private set; }
    
    public CustomerDTO(
        int customerID,
        string firstName,
        string lastName,
        string email,
        string phone,
        string city,
        DateTime registrationDate,
        int loyaltyPoints,
        string status)
    {
        this.CustomerID = customerID;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Phone = phone;
        this.City = city;
        this.RegistrationDate = registrationDate;
        this.LoyaltyPoints = loyaltyPoints;
        this.Status = status;
    }
}