using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.BL;
using NovaBusinessSystem.Enumeration;
using nHelpersPL;

namespace NovaBusinessSystem.PL
{


    public class CustomersPL 
    {
        private static void PrintDetail(string label, object? value, int numberTabs)
        {
            const int ContentWidth = 50;

            string Text = $"{label,-20} : {value ?? " "}";

            if (Text.Length > ContentWidth)
                Text = Text[..ContentWidth];


            Console.WriteLine($"{HelperPL.GenarateTabs(numberTabs)}║ {Text,-48}║");
        }

        private static void _ShowSccessMessageAndShowInformationCustomer(CustomersBL informationCustomer, string message)
        {

            int width = 50;
            int contentWidth = width - 2;

            int paddingLeft = (contentWidth - message.Length) / 2;
            int paddingRight = contentWidth - message.Length - paddingLeft - 1;

            System.Console.WriteLine("\n\n\n");
            Console.WriteLine($"\n\n{HelperPL.GenarateTabs(7)}╔═════════════════════════════════════════════════╗");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║{new string(' ', paddingLeft)}{message}{new string(' ', paddingRight)} ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╚═════════════════════════════════════════════════╝");

            PrintDetail("Customer ID", informationCustomer.CustomerID, 7);
            PrintDetail("First Name", informationCustomer.FirstName, 7);
            PrintDetail("Last Name", informationCustomer.LastName, 7);
            PrintDetail("Email", informationCustomer.Email, 7);
            PrintDetail("Phone", informationCustomer.Phone, 7);
            PrintDetail("City", informationCustomer.City.Trim(), 7);
            PrintDetail("Registration Date", $"{informationCustomer.RegistrationDate.ToString("dd/MM/yyyy")}", 7);
            PrintDetail("Status", informationCustomer.Status, 7);
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╚═════════════════════════════════════════════════╝");
        }

        private static void _MainMenuCustomersModule()
        {
            Console.WriteLine($"\n\n\n{HelperPL.GenarateTabs(7)}╔══════════════════════════════════════════╗");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║              👥 CUSTOMERS                ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  1. 📋 List Customers                    ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  2. 🔎 Get Customer By ID                ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  3. ➕ Add Customer                      ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  4. ✏️  Update Customer                   ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  5. 🗑️  Delete Customer                   ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  6. 🔍 Search Customers                  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  7. ⭐ Loyalty Points                    ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  8. 🛒 Customer Purchases                ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  9. 📊 Customer Report                   ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  0. 🔙 Back                              ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝");

        }

        private static void _PrintCustomerDetails(CustomersBL informationCustomer, string? title)
        {
            if ((informationCustomer is null) || string.IsNullOrWhiteSpace(title))
                return;

            HelperPL.PrintHeader(title, 7);

            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"ID",-16} : {informationCustomer.CustomerID,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Name",-16} : {string.Join(" ", informationCustomer.FirstName, informationCustomer.LastName),-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Email",-16} : {informationCustomer.Email,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Phone",-16} : {informationCustomer.Phone,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"City",-16} : {informationCustomer.City,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Registration",-16} : {informationCustomer.RegistrationDate,-20:dd/MM/yyyy}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Loyalty Points",-16} : {informationCustomer.LoyaltyPoints,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Status",-16} : {informationCustomer.Status,-20}  ║");

            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝");
        }

        private static void _CustomersList()
        {
            Console.Clear();

            System.Console.WriteLine("\n\n");

            HelperPL.PrintHeader("📋 CUSTOMER LIST", 7);
            System.Console.WriteLine("\n\n\n");
            System.Console.WriteLine($"\t\t{"ID",-15} {"Name",-30} {"Email",-40} {"City",-15} {"Points",-10} {"Status",-15}");

            System.Console.WriteLine($"\t\t{new string('-', 123)}");
            List<CustomerDTO> L_ALlCustomers = CustomersBL.GetCustomersList().ToList();

            foreach (var Item_Customer in L_ALlCustomers)
                System.Console.WriteLine($"\t\t{Convert.ToInt32(Item_Customer.CustomerID),-15} {string.Join(" ", Item_Customer.FirstName, Item_Customer.LastName),-30} {Item_Customer.Email,-40} {Item_Customer.City,-15} {Convert.ToInt32(Item_Customer.LoyaltyPoints),-10} {Item_Customer.Status,-15}");
            System.Console.WriteLine($"\t\t{new string('-', 123)}\n\n");

            System.Console.WriteLine($"\t\tTotal Customers: {L_ALlCustomers.Count}\n\n");


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
            string? firstName = HelperPL.ReadTheStringWithoutNumbers("First Name", 15, 7);
            string? lastName = HelperPL.ReadTheStringWithoutNumbers("Last Name", 15, 7);
            string? Email = HelperPL.ReadTheStringWithoutNumbers("Email", 15, 7);
            string? Phone = HelperPL.ReadTheStringWithNumbers<string>("Phone", 15, 7);
            string? City = HelperPL.ReadTheStringWithoutNumbers("City", 15, 7);

            byte status = 0;

            System.Console.Write($"{HelperPL.GenarateTabs(7)}Status (Active:1 , Inactive:0 , Blocked:2) : ");
            while (!byte.TryParse(Console.ReadLine(), out status))
                System.Console.Write($"{HelperPL.GenarateTabs(7)}Try Agian , Status (Active:1 , Inactive:0 , Blocked:2) : ");

            string StatusString = GetStatus(status);

            return new CustomerDTO(-1, firstName!, lastName!, Email!, Phone!, City!, DateTime.Now, (short)0, StatusString);

        }

        private static int ReadTheID()
        {
            Console.Clear();
            System.Console.WriteLine("\n\n\n");

            HelperPL.PrintHeader("🔎 GET CUSTOMER BY ID", 7);
            System.Console.WriteLine("\n\n");
            System.Console.Write($"{HelperPL.GenarateTabs(7)}Enter Customer ID: ");
            int ID = -1;
            while (!int.TryParse(Console.ReadLine(), out ID))
                System.Console.Write($"{HelperPL.GenarateTabs(7)}Invalid Data ID : ");

            System.Console.WriteLine("\n\n");


            return ID;
        }

        private static CustomersBL? GetCustomerByID()
        {

            System.Console.WriteLine("\n\n");
            CustomersBL customerInfo = CustomersBL.Find(ReadTheID())!;

            try
            {
                if (customerInfo is not null)
                    _PrintCustomerDetails(customerInfo, "👤 CUSTOMER DETAILS");
                else HelperPL.ShowNotFoundMessage($"Employee with ID {customerInfo?.CustomerID} was not found.", "❌ NOT FOUND", "Customer could not be found.");

            }
            catch (SqlException SEX)
            {
                HelperPL.ShowNotFoundMessage(SEX.Message, "❌ NOT FOUND", "Customer could not be found.");
            }

            return customerInfo;
        }

        private static void AddNewCustomer()
        {

            Console.Clear();
            System.Console.WriteLine("\n\n\n");
            HelperPL.PrintHeader("➕ ADD CUSTOMER", 7);

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
                HelperPL.ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT ADDED", "Customer could not be added.");
            }

        }

        private static void _UpdateCustomer()
        {

            Console.Clear();

            try
            {
                CustomersBL infoCustomer = GetCustomerByID()!;
                System.Console.WriteLine("\n\n\n");
                HelperPL.PrintHeader("UPDATE CUSTOMER", 7);
                if (infoCustomer is not null)
                {
                    System.Console.WriteLine("\n\n");

                    CustomerDTO? customer = ReadInformationCustoemr();
                    infoCustomer.ConvertDTOtoObject(customer!);

                    if (infoCustomer!.SaveModeCustomer())
                    {
                        _ShowSccessMessageAndShowInformationCustomer(infoCustomer, "✅ CUSTOMER UPDATED");
                    }
                }

            }
            catch (SqlException SEX)
            {
                HelperPL.ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT UPDATED", "Customer could not be UPDATED.");
            }

        }

        private static void _DeleteCustomer()
        {

            Console.Clear();

            try
            {
                CustomersBL infoCustomer = GetCustomerByID()!;
                System.Console.WriteLine("\n\n\n");
                HelperPL.PrintHeader("🗑️  DELETE CUSTOMER", 7);

                if (infoCustomer is not null)
                {
                    System.Console.WriteLine("\n\n");

                    Console.Write($"{HelperPL.GenarateTabs(7)}Are you sure you want to delete this customer?\n");
                    Console.Write($"{HelperPL.GenarateTabs(7)}Y = Yes N = No  Choice: ");
                    char choice = 'n';

                    while (!char.TryParse(Console.ReadLine(), out choice) || char.ToLower(choice) is not ('y' or 'n'))

                        Console.Write($"{HelperPL.GenarateTabs(7)}Invalid Choive , pLease Enter valid choive -> Y = Yes N = No  Choice: ");

                    if (char.ToLower(choice) == 'y')
                    {
                        if (infoCustomer.DeleteCustomer())
                            _ShowSccessMessageAndShowInformationCustomer(infoCustomer, "✅ CUSTOMER DELETED");
                        else
                            HelperPL.ShowNotFoundMessage("❌ DELETE FAILED", "This customer cannot be deleted because\nthey have existing sales records.");
                    }
                    else
                        HelperPL.ShowNotFoundMessage("ℹ️  DELETE CANCELLED ", "No changes were made.");
                }

            }
            catch (SqlException SEX)
            {
                HelperPL.ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT UPDATED", "Customer could not be UPDATED.");
            }

        }

        public static async Task StartUpCustomersModule()
        {

            while (true)
            {
                Console.Clear();

                _MainMenuCustomersModule();

                Console.Write($"\n\n\n{HelperPL.GenarateTabs(7)}Select: ");
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

                    case Enumerations.EnChoicesCustomersModule._kUPDATE_INFORMATION_CUSTOMER:
                        {
                            _UpdateCustomer();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kDELETE_CUSTOMER:
                        {
                            _DeleteCustomer();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kLOYALTY_POINTS:
                        {
                            await Loyalty.StartUpLoyaltyPointsSection();
                            break;
                        }
                }


                Console.WriteLine($"\n{HelperPL.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }


    }
}