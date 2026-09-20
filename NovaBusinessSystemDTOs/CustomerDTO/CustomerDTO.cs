namespace NovaBusinessSystemDTOs;

public class CustomerDTO
{
    public int CustomerID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public DateTime RegistrationDate { get; private set; }
    public short LoyaltyPoints { get; private set; }
    public bool Status { get; private set; }

    public CustomerDTO(
        int customerID,
        string name,
        string email,
        string phone,
        string city,
        DateTime registrationDate,
        short loyaltyPoints,
        bool status)
    {
        this.CustomerID = customerID;
        this.Name = name;
        this.Email = email;
        this.Phone = phone;
        this.City = city;
        this.RegistrationDate = registrationDate;
        this.LoyaltyPoints = loyaltyPoints;
        this.Status = status;
    }
}