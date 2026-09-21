using System.Data;
using nCustomersDAL;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.BL
{
    public class CustomersBL
    {


        public int CustomerID { get; set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public short LoyaltyPoints { get; set; }
        public string Status { get; set; }

        public Enumerations.EnMode enMode { get; set; }
            = Enumerations.EnMode._kADD;

        public CustomersBL()
        {
            this.CustomerID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.City = "";
            this.RegistrationDate = DateTime.Now;
            this.LoyaltyPoints = 0;
            this.Status = "";
            this.enMode = Enumerations.EnMode._kADD ; 

        }

        private CustomersBL(
           CustomerDTO customerDTO
            )
        {
            this.CustomerID = customerDTO.CustomerID;
            this.FirstName = customerDTO.FirstName;
            this.LastName = customerDTO.LastName;
            this.Email = customerDTO.Email;
            this.Phone = customerDTO.Phone;
            this.City = customerDTO.City;
            this.RegistrationDate = customerDTO.RegistrationDate;
            this.LoyaltyPoints = customerDTO.LoyaltyPoints;
            this.Status = customerDTO.Status;

            this.enMode = Enumerations.EnMode._kUPDATE;
        }

        private CustomerDTO ConvertToDTO()
        {
            return new CustomerDTO(

                this.CustomerID,
                this.FirstName,
                this.LastName,
                this.Email,
                this.Phone,
                this.City,
                this.RegistrationDate,
                this.LoyaltyPoints,
                this.Status

            );
        }

        public  CustomersBL? ConvertDTOtoObject(CustomerDTO customer)
        {
            if (customer is not null)
            {
                this.CustomerID = customer.CustomerID;
                this.FirstName = customer.FirstName;
                this.LastName = customer.LastName;
                this.Email = customer.Email;
                this.Phone = customer.Phone;
                this.City = customer.City;
                this.RegistrationDate = customer.RegistrationDate;
                this.LoyaltyPoints = customer.LoyaltyPoints;
                this.Status = customer.Status;
            }

            return null;
        }

        public static CustomersBL? Find(int id)
        {

            CustomerDTO? infoCustomer = CustomersDAL.FindCustomerBy(id);

            if (infoCustomer is not null)
                return new CustomersBL(infoCustomer);

            return null;
        }

        private bool _AddNewCustomer()
        {
            this.CustomerID = CustomersDAL.AddNewCustomer(ConvertToDTO());
            return this.CustomerID > 0;
        }

        public static DataTable GetCustomersList() => CustomersDAL.GetAllCustomersList();

        public bool SaveModeCustomer()
        {
            switch (this.enMode)
            {
                case Enumerations.EnMode._kADD:
                    {
                        if (_AddNewCustomer())
                        {
                            this.enMode = Enumerations.EnMode._kUPDATE;
                            return true;
                        }
                        else return false;
                    }
                case Enumerations.EnMode._kUPDATE:
                    return false;

                default: return false;

            }
        }
    }

}