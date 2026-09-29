namespace NovaBusinessSystem.DTOs.Customers.Reports
{
    public class RegistrationSummaryDTO
    {
        public int Year { get; private set; }
        public int NewCustomers { get; private set; }

        public RegistrationSummaryDTO(int year, int newCustomers)
        {
            this.Year = year;
            this.NewCustomers = newCustomers;
        }
    }
}