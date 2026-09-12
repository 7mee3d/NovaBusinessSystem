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
            Console.WriteLine("\n\n\n\t\t╔══════════════════════════════════════════╗");
            Console.WriteLine("\t\t║              👥 CUSTOMERS                ║");
            Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
            Console.WriteLine("\t\t║                                          ║");
            Console.WriteLine("\t\t║  1. 📋 List Customers                    ║");
            Console.WriteLine("\t\t║  2. 🔎 Get Customer By ID                ║");
            Console.WriteLine("\t\t║  3. ➕ Add Customer                      ║");
            Console.WriteLine("\t\t║  4. ✏️  Update Customer                   ║");
            Console.WriteLine("\t\t║  5. 🗑️  Delete Customer                   ║");
            Console.WriteLine("\t\t║  6. 🔍 Search Customers                  ║");
            Console.WriteLine("\t\t║  7. ⭐ Loyalty Points                    ║");
            Console.WriteLine("\t\t║  8. 🛒 Customer Purchases                ║");
            Console.WriteLine("\t\t║  9. 📊 Customer Report                   ║");
            Console.WriteLine("\t\t║                                          ║");
            Console.WriteLine("\t\t║  0. 🔙 Back                              ║");
            Console.WriteLine("\t\t║                                          ║");
            Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

        }

        private static void _CustomersList()
        {
            Console.Clear();

            System.Console.WriteLine("\n\n");

            //Console.WriteLine($"\n\n{GenarateTabs(7)}╔══════════════════════════════════════════╗");
           // Console.WriteLine($"{GenarateTabs(7)}║             📋 CUSTOMER LIST             ║");
            //Console.WriteLine($"{GenarateTabs(7)}╚══════════════════════════════════════════╝\n\n\n");

            PrintHeader("📋 CUSTOMER LIST" , 7 );
  // PrintHeader("🔎 GET CUSTOMER BY ID" , 7 );
            System.Console.WriteLine($"\t\t{"ID",-15} {"Name",-30} {"Email",-40} {"City",-15} {"Points",-10} {"Status",-15}");

            System.Console.WriteLine($"\t\t{new string('-', 123)}");
            DataTable DT_ALlCustomers = CustomersBL.GetCustomersList();

            foreach (DataRow DR_Customer in DT_ALlCustomers.Rows)
                System.Console.WriteLine($"\t\t{Convert.ToInt32(DR_Customer["CustomerID"]),-15} {DR_Customer["Name"].ToString(),-30} {DR_Customer["Email"].ToString(),-40} {DR_Customer["City"].ToString(),-15} {Convert.ToInt32(DR_Customer["LoyaltyPoints"]),-10} {DR_Customer["Status"],-15}");
            System.Console.WriteLine($"\t\t{new string('-', 123)}\n\n");

            System.Console.WriteLine($"\t\tTotal Customers: {DT_ALlCustomers.Rows.Count}\n\n");


        }

        public static void StartUpCustomersModule()
        {

            while (true)
            {
                Console.Clear();

                _MainMenuCustomersModule();

                Console.Write("\n\n\n\t\tSelect: ");
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
                }


                Console.WriteLine("\n\t\tPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}