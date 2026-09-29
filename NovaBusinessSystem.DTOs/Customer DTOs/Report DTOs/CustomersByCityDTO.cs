namespace NovaBusinessSystem.DTOs.Customers.Reports
{
    public class CustomersByCityDTO
    {
        public string City { get; private set; }
        public int Customers { get; private set; }

        public CustomersByCityDTO(string city, int customers)
        {
            this.City = city;
            this.Customers = customers;
        }
    }
}