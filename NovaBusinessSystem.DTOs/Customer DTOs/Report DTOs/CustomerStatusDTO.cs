namespace NovaBusinessSystem.DTOs.Customers.Reports
{
    public class CustomerStatusDTO
    {
        public string Status { get; set; }
        public int Customers { get; set; }

        public CustomerStatusDTO(string status, int customers)
        {
            this.Status = status;
            this.Customers = customers;
        }
    }
}