
using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystemPL.Modules.Customers;

namespace NovaBusinessSystem.Modules.Customers.Purchases
{
    public static class PurchasesMenu
    {
        private static void _PrintMenuPurchasesCustomers()
        {
            System.Console.WriteLine("\n\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║            🛒 CUSTOMER PURCHASES         ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  1. Purchase History                     ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  2. Customer Spending Summary            ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  3. Customer Favorite Products           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  4. Customer Monthly Purchases           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  5. Customer Ranking                     ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n\n");

        }

        public static async Task StartupPurchasesCustomers()
        {
            while (true)
            {
                Console.Clear();
                _PrintMenuPurchasesCustomers();
                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 5)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Incorrect choice try agian : ");

                switch ((Enumerations.EnChoicesCustomerPurchases)choice)
                {
                    case Enumerations.EnChoicesCustomerPurchases._kBACK:
                        {
                            await CustomersPL.StartUpCustomersModule();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kPURCHASE_HISTORY:
                        {
                            await PurchasesOperations.GetPurchaseHistory();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kCUSTOMER_SPENDING_SUMMARY:
                        {
                            await PurchasesOperations.GetCustomerSpendingSummary();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kCUSTOMER_MONTHLY_PURCHASES:
                        {
                            await PurchasesOperations.GetCustomerMonthlyPurchases();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kCUSTOMER_RANKING:
                        {
                            await PurchasesOperations.GetCustomersRankingAsync();
                            break;
                        }

                }


                Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }

    }
}