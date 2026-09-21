using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.BL;
using NovaBusinessSystem.Enumeration;
using nHelpersPL;

namespace CustomersPL
{


    public class CustomersPL : HelperPL
    {
        private static void PrintDetail(string label, object? value, int numberTabs)
        {
            const int ContentWidth = 50;

            string Text = $"{label,-20} : {value ?? " "}";

            if (Text.Length > ContentWidth)
                Text = Text[..ContentWidth];


            Console.WriteLine($"{GenarateTabs(numberTabs)}║ {Text,-48}║");
        }

        private static void _ShowSccessMessageAndShowInformationCustomer(CustomersBL informationCustomer, string message)
        {

            int width = 50;
            int contentWidth = width - 2;

            int paddingLeft = (contentWidth - message.Length) / 2;
            int paddingRight = contentWidth - message.Length - paddingLeft - 1;

            System.Console.WriteLine("\n\n\n");
            Console.WriteLine($"\n\n{GenarateTabs(7)}╔═════════════════════════════════════════════════╗");
            Console.WriteLine($"{GenarateTabs(7)}║{new string(' ', paddingLeft)}{message}{new string(' ', paddingRight)} ║");
            Console.WriteLine($"{GenarateTabs(7)}╚═════════════════════════════════════════════════╝");

            PrintDetail("Customer ID", informationCustomer.CustomerID, 7);
            PrintDetail("First Name", informationCustomer.FirstName, 7);
            PrintDetail("Last Name", informationCustomer.LastName, 7);
            PrintDetail("Email", informationCustomer.Email, 7);
            PrintDetail("Phone", informationCustomer.Phone, 7);
            PrintDetail("City", informationCustomer.City.Trim(), 7);
            PrintDetail("Registration Date", $"{informationCustomer.RegistrationDate.ToString("dd/MM/yyyy")}", 7);
            PrintDetail("Status", informationCustomer.Status, 7);
            Console.WriteLine($"{GenarateTabs(7)}╚═════════════════════════════════════════════════╝");
        }
        private static void _MainMenuCustomersModule()
        {
            Console.WriteLine($"\n\n\n{GenarateTabs(7)}╔══════════════════════════════════════════╗");
            Console.WriteLine($"{GenarateTabs(7)}║              👥 CUSTOMERS                ║");
            Console.WriteLine($"{GenarateTabs(7)}╠══════════════════════════════════════════╣");
            Console.WriteLine($"{GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{GenarateTabs(7)}║  1. 📋 List Customers                    ║");
            Console.WriteLine($"{GenarateTabs(7)}║  2. 🔎 Get Customer By ID                ║");
            Console.WriteLine($"{GenarateTabs(7)}║  3. ➕ Add Customer                      ║");
            Console.WriteLine($"{GenarateTabs(7)}║  4. ✏️  Update Customer                   ║");
            Console.WriteLine($"{GenarateTabs(7)}║  5. 🗑️  Delete Customer                   ║");
            Console.WriteLine($"{GenarateTabs(7)}║  6. 🔍 Search Customers                  ║");
            Console.WriteLine($"{GenarateTabs(7)}║  7. ⭐ Loyalty Points                    ║");
            Console.WriteLine($"{GenarateTabs(7)}║  8. 🛒 Customer Purchases                ║");
            Console.WriteLine($"{GenarateTabs(7)}║  9. 📊 Customer Report                   ║");
            Console.WriteLine($"{GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{GenarateTabs(7)}║  0. 🔙 Back                              ║");
            Console.WriteLine($"{GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{GenarateTabs(7)}╚══════════════════════════════════════════╝");

        }

        private static void _PrintCustomerDetails(CustomersBL informationCustomer, string? title)
        {
            if ((informationCustomer is null) || string.IsNullOrWhiteSpace(title))
                return;

            PrintHeader(title, 7);

            Console.WriteLine($"{GenarateTabs(7)}║ {"ID",-16} : {informationCustomer.CustomerID,-20}  ║");
            Console.WriteLine($"{GenarateTabs(7)}║ {"Name",-16} : {string.Join(" ", informationCustomer.FirstName, informationCustomer.LastName),-20}  ║");
            Console.WriteLine($"{GenarateTabs(7)}║ {"Email",-16} : {informationCustomer.Email,-20}  ║");
            Console.WriteLine($"{GenarateTabs(7)}║ {"Phone",-16} : {informationCustomer.Phone,-20}  ║");
            Console.WriteLine($"{GenarateTabs(7)}║ {"City",-16} : {informationCustomer.City,-20}  ║");
            Console.WriteLine($"{GenarateTabs(7)}║ {"Registration",-16} : {informationCustomer.RegistrationDate,-20:dd/MM/yyyy}  ║");
            Console.WriteLine($"{GenarateTabs(7)}║ {"Loyalty Points",-16} : {informationCustomer.LoyaltyPoints,-20}  ║");
            Console.WriteLine($"{GenarateTabs(7)}║ {"Status",-16} : {informationCustomer.Status,-20}  ║");

            Console.WriteLine($"{GenarateTabs(7)}╚══════════════════════════════════════════╝");
        }

        private static void _CustomersList()
        {
            Console.Clear();

            System.Console.WriteLine("\n\n");

            PrintHeader("📋 CUSTOMER LIST", 7);
            System.Console.WriteLine($"\t\t{"ID",-15} {"Name",-30} {"Email",-40} {"City",-15} {"Points",-10} {"Status",-15}");

            System.Console.WriteLine($"\t\t{new string('-', 123)}");
            DataTable DT_ALlCustomers = CustomersBL.GetCustomersList();

            foreach (DataRow DR_Customer in DT_ALlCustomers.Rows)
                System.Console.WriteLine($"\t\t{Convert.ToInt32(DR_Customer["CustomerID"]),-15} {DR_Customer["Name"].ToString(),-30} {DR_Customer["Email"].ToString(),-40} {DR_Customer["City"].ToString(),-15} {Convert.ToInt32(DR_Customer["LoyaltyPoints"]),-10} {DR_Customer["Status"],-15}");
            System.Console.WriteLine($"\t\t{new string('-', 123)}\n\n");

            System.Console.WriteLine($"\t\tTotal Customers: {DT_ALlCustomers.Rows.Count}\n\n");


        }

        private static string GetStatus(byte status)
        {
            switch (status)
            {
                case 0:
                    return "Inactive";
                case 1:
                    return "Active";
                case 2:
                    return "Blocked";

                default: return "";
            }
        }

        private static CustomerDTO? ReadInformationCustoemr()
        {
            string? firstName = ReadTheStringWithoutNumbers("First Name", 15, 7);
            string? lastName = ReadTheStringWithoutNumbers("Last Name", 15, 7);
            string? Email = ReadTheStringWithoutNumbers("Email", 15, 7);
            string? Phone = ReadTheStringWithNumbers<string>("Phone", 15, 7);
            string? City = ReadTheStringWithoutNumbers("City", 15, 7);

            byte status = 0;

            System.Console.Write($"{GenarateTabs(7)}Status (Active:1 , Inactive:0 , Blocked:2) : ");
            while (!byte.TryParse(Console.ReadLine(), out status))
                System.Console.Write($"{GenarateTabs(7)}Try Agian , Status (Active:1 , Inactive:0 , Blocked:2) : ");

            string StatusString = GetStatus(status);

            return new CustomerDTO(-1, firstName!, lastName!, Email!, Phone!, City!, DateTime.Now, (short)0, StatusString);

        }

        private static void GetCustomerByID()
        {
            Console.Clear();

            PrintHeader("🔎 GET CUSTOMER BY ID", 7);
            System.Console.WriteLine("\n\n");
            System.Console.Write($"{GenarateTabs(7)}Enter Customer ID: ");
            int ID = -1;
            while (!int.TryParse(Console.ReadLine(), out ID))
                System.Console.Write($"{GenarateTabs(7)}Invalid Data ID : ");

            System.Console.WriteLine("\n\n");
            CustomersBL customerInfo = CustomersBL.Find(ID)!;

            try
            {
                if (customerInfo is not null)
                    _PrintCustomerDetails(customerInfo, "👤 CUSTOMER DETAILS");
                else ShowNotFoundMessage($"Employee with ID {ID} was not found.", "❌ NOT FOUND", "Customer could not be found.");

            }
            catch (SqlException SEX)
            {
                ShowNotFoundMessage(SEX.Message, "❌ NOT FOUND", "Customer could not be found.");
            }
        }

        private static void AddNewCustomer()
        {

            Console.Clear();
            System.Console.WriteLine("\n\n\n");
            PrintHeader("➕ ADD CUSTOMER", 7);

            try
            {
                CustomerDTO? customer = ReadInformationCustoemr();
                CustomersBL? customersBL = new CustomersBL();
                customersBL.ConvertDTOtoObject(customer!);

                if (customersBL!.SaveModeCustomer())
                {
                    _ShowSccessMessageAndShowInformationCustomer(customersBL, "✅ CUSTOMER ADDED");
                }


            }
            catch (SqlException SEX)
            {
                ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT ADDED", "Customer could not be added.");
            }

        }

        public static void StartUpCustomersModule()
        {

            while (true)
            {
                Console.Clear();

                _MainMenuCustomersModule();

                Console.Write($"\n\n\n{GenarateTabs(7)}Select: ");
                byte ChoiceCustomer = 0;
                while (!byte.TryParse(Console.ReadLine(), out ChoiceCustomer) || ChoiceCustomer > 9)
                    System.Console.WriteLine("\t\tInvalid Choice Customer Menu ");

                switch ((Enumerations.EnChoicesCustomersModule)ChoiceCustomer)
                {
                    case Enumerations.EnChoicesCustomersModule._kLIST_CUSTOMERS:
                        {
                            _CustomersList();
                            break;

                        }
                    case Enumerations.EnChoicesCustomersModule._kGET_CUSTOMER_BY_ID:
                        {
                            GetCustomerByID();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kADD_NEW_CUSTOMER:
                        {
                            AddNewCustomer();
                            break;
                        }
                }


                Console.WriteLine($"\n{GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}