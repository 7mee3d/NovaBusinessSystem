using System.Data;
using System.Linq.Expressions;
using nCustomersBL;
using nEnumeration;
using nHelpersPL;

namespace CustomersPL
{


    public class CustomersPL : HelperPL
    {
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
            Console.WriteLine($"{GenarateTabs(7)}║ {"Name",-16} : {informationCustomer.Name,-20}  ║");
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
            // PrintHeader("🔎 GET CUSTOMER BY ID" , 7 );
            System.Console.WriteLine($"\t\t{"ID",-15} {"Name",-30} {"Email",-40} {"City",-15} {"Points",-10} {"Status",-15}");

            System.Console.WriteLine($"\t\t{new string('-', 123)}");
            DataTable DT_ALlCustomers = CustomersBL.GetCustomersList();

            foreach (DataRow DR_Customer in DT_ALlCustomers.Rows)
                System.Console.WriteLine($"\t\t{Convert.ToInt32(DR_Customer["CustomerID"]),-15} {DR_Customer["Name"].ToString(),-30} {DR_Customer["Email"].ToString(),-40} {DR_Customer["City"].ToString(),-15} {Convert.ToInt32(DR_Customer["LoyaltyPoints"]),-10} {DR_Customer["Status"],-15}");
            System.Console.WriteLine($"\t\t{new string('-', 123)}\n\n");

            System.Console.WriteLine($"\t\tTotal Customers: {DT_ALlCustomers.Rows.Count}\n\n");


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
            _PrintCustomerDetails(CustomersBL.Find(ID)!, "👤 CUSTOMER DETAILS");
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
                }


                Console.WriteLine($"\n{GenarateTabs(5)}Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}