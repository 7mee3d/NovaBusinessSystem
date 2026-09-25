using nHelpersPL;
using NovaBusinessSystem.Enumeration ; 

namespace NovaBusinessSystem.PL
{

    public class CustomerPurchasesPL
    {
        private static void _PrintMenuPurchasesCustomers()
        {
            System.Console.WriteLine("\n\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║            🛒 CUSTOMER PURCHASES         ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  1. Purchase History                     ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  2. Customer Spending Summary             ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  3. Customer Favorite Products            ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  4. Customer Monthly Purchases            ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  5. Customer Ranking                      ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝\n\n");

        }


        public static async Task _StartupPurchasesCustomers()
        {
            while (true)
            {
                Console.Clear();
                _PrintMenuPurchasesCustomers();
                Console.Write($"{HelperPL.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 5)
                    Console.Write($"{HelperPL.GenarateTabs(7)}Incorrect choice try agian : ");

                switch ((Enumerations.EnChoicesCustomerPurchases)choice)
                {
                    case Enumerations.EnChoicesCustomerPurchases._kBACK :
                        {
                            await CustomersPL.StartUpCustomersModule();
                            break;
                        }
                    
                }
            }
        }
    }
}