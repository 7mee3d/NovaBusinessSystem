namespace NovaBusinessSystem.DTOs;

public class CustomerAddDTO
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Status { get; private set; }
    
    public CustomerAddDTO(
        string firstName,
        string lastName,
        string email,
        string phone,
        string city,
        string status
        )
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Phone = phone;
        this.City = city;
        this.Status = status;
    }
}