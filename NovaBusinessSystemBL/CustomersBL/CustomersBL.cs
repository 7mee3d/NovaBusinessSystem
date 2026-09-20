using System.Data;
using nCustomersDAL;
using nEnumeration;
using NovaBusinessSystemDTOs;

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

        private CustomersBL(
           CustomerDTO customerDTO
            )
        {
            this.CustomerID = customerDTO.CustomerID;
            this.Name = customerDTO.Name;
            this.Email = customerDTO.Email;
            this.Phone = customerDTO.Phone;
            this.City = customerDTO.City;
            this.RegistrationDate = customerDTO.RegistrationDate;
            this.LoyaltyPoints = customerDTO.LoyaltyPoints;
            this.Status = customerDTO.Status;

            this.enMode = Enumerations.EnMode._kUPDATE;
        }

        public static CustomersBL? Find(int id)
        {

            CustomerDTO? infoCustomer = CustomersDAL.FindCustomerBy(id);

            if (infoCustomer is not null)
                return new CustomersBL(infoCustomer);

            return null;
        }

        public static DataTable GetCustomersList() => CustomersDAL.GetAllCustomersList();
    }

}