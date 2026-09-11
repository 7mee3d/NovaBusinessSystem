using System.Linq.Expressions;
using nEnumeration;

namespace CustomersPL
{


    public class CustomersPL
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

        public static void StartUpCustomersModule()
        {

            while (true)
            {
                Console.Clear();

                _MainMenuCustomersModule();

                Console.Write("\n\n\n\t\tSelect: ");
                byte ChoiceCustomer = 0 ; 
                while (!byte.TryParse(Console.ReadLine() , out ChoiceCustomer) || ChoiceCustomer > 9 )
                    System.Console.WriteLine("\t\tInvalid Choice Customer Menu ");

                switch ((Enumerations.EnChoicesCustomersModule)ChoiceCustomer)
                {
                    
                }


                Console.WriteLine("\n\t\tPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}