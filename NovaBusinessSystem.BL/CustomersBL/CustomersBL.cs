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
        public int LoyaltyPoints { get; set; }
        public string Status { get; set; }
        public CustomerDTO CDTO
        {
            get
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
        }
        public CustomerAddDTO CAddDTO
        {
            get
            {
                return new CustomerAddDTO(
                this.FirstName,
                this.LastName,
                this.Email,
                this.Phone,
                this.City,
                this.Status
                );
            }
        }

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
            this.enMode = Enumerations.EnMode._kADD;

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

        private CustomerAddDTO ConvertCustomerAddToDTO()
        {
            return new CustomerAddDTO(

                this.FirstName,
                this.LastName,
                this.Email,
                this.Phone,
                this.City,
                this.Status

            );
        }

        public void ConvertDTOtoObject(CustomerDTO customer)
        {
            if (customer is not null)
            {
                this.FirstName = customer.FirstName;
                this.LastName = customer.LastName;
                this.Email = customer.Email;
                this.Phone = customer.Phone;
                this.City = customer.City;
                this.Status = customer.Status;
            }
        }

        public CustomersBL? ConvertAddDTOtoObject(CustomerAddDTO customer)
        {
            if (customer is not null)
            {
                this.FirstName = customer.FirstName;
                this.LastName = customer.LastName;
                this.Email = customer.Email;
                this.Phone = customer.Phone;
                this.City = customer.City;
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
            this.CustomerID = CustomersDAL.AddNewCustomer(ConvertCustomerAddToDTO());
            return this.CustomerID > 0;
        }

        private bool _UpdateCustomer()
        {
            return CustomersDAL.UpdateCustomer(this.CustomerID, this.CAddDTO) > 0;
        }

        public static IEnumerable<CustomerDTO> GetCustomersList() => CustomersDAL.GetAllCustomersList();

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
                    return _UpdateCustomer();

                default: return false;

            }
        }

        public static bool CheckStringIsValid(string text)
        {
            bool isFound = true;

            if (text == "")
                return false;

            if (!string.IsNullOrWhiteSpace(text))
                foreach (char character in text)
                {
                    if (char.IsDigit(character) || char.IsPunctuation(character) || Char.IsNumber(character) || char.IsSymbol(character) || char.IsWhiteSpace(character))
                    {
                        isFound = false;
                        break;
                    }

                }

            return isFound;
        }

        public static bool IsEmailExists(string Email) => CustomersDAL.IsTheEmailExists(Email);

        public static bool IsStatusValid(string Status)
        {
            if (Status == "Active" || Status == "Inactive" || Status == "Blocked")
                return true;

            return false;
        }

        public bool DeleteCustomer() => CustomersDAL.DeleteCustomer(this.CustomerID);

        // 

        public static async Task<CustomerPointsDTO>? ViewCustomerPointsAsync(int id)
         => await CustomersDAL.ViewCustomerPoints(id)!;

        public async Task<bool> AddPointsToCustomerAsync(int pointsToAdd)
        => await CustomersDAL.AddPointsToCustomer(this.CustomerID, pointsToAdd)!;

        public async Task<bool> RedeemPointsToCustomerAsync(int pointsToAdd)
        => await CustomersDAL.RedeemPointsToCustomer(this.CustomerID, pointsToAdd)!;

        public static async Task<IEnumerable<TopLoyaltyCustomerDTO>>? GetTopLoyaltyCustomersAsync()
        => await CustomersDAL.GetTopLoyaltyCustomers()!;
    }

}