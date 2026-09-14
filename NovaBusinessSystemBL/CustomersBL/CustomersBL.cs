using System.Data;
using nCustomersDAL;
using nEnumeration;

namespace nCustomersBL
{
    public class CustomersBL
    {
        public int CustomerID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public short LoyaltyPoints { get; set; }
        public bool Status { get; set; }

        public Enumerations.EnMode enMode { get; set; }
            = Enumerations.EnMode._kADD;

        public CustomersBL()
        {
            this.CustomerID = -1;
            this.Name = "";
            this.Email = "";
            this.Phone = "";
            this.City = "";
            this.RegistrationDate = DateTime.Now;
            this.LoyaltyPoints = 0;
            this.Status = true;
        }

        public CustomersBL(
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

            this.enMode = Enumerations.EnMode._kUPDATE;
        }

        public static CustomersBL? Find(int id)
        {
            string name = "", email = "", phone = "", city = "";
            DateTime registrationDate = DateTime.Now;
            short loyaltyPoints = 0;
            bool status = true;

            bool isFound = CustomersDAL.FindCustomerBy(
                id,
                ref name,
                ref email,
                ref phone,
                ref city,
                ref registrationDate,
                ref loyaltyPoints,
                ref status
            );

            if (isFound)
            {
                return new CustomersBL(
                    id,
                    name,
                    email,
                    phone,
                    city,
                    registrationDate,
                    loyaltyPoints,
                    status
                );
            }

            return null;
        }

        public static DataTable GetCustomersList() => CustomersDAL.GetAllCustomersList();
    }

}