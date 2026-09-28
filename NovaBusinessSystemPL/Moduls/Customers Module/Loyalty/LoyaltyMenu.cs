using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystemPL.Modules.Customers;

namespace NovaBusinessSystem.Modules.Customers.Loyalty
{

    public class LoyaltyMenu
    {

        private static void _PrintMenuLoyaltyPoints()
        {
            System.Console.WriteLine("\n\n\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║            ⭐ LOYALTY POINTS             ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  1. View Customer Points                 ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  2. Add Points                           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  3. Redeem Points                        ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  4. Top Loyalty Customers                ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  5. Loyalty Statistics                   ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n\n\n");


        }

        public static async Task StartUpLoyaltyPointsSection()
        {
            while (true)
            {

                Console.Clear();
                _PrintMenuLoyaltyPoints();

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 5)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Invalid Choive Select another choice : ");

                switch ((Enumerations.EnChoicesLoyaltyPoints)choice)
                {
                    case Enumerations.EnChoicesLoyaltyPoints._kVIEW_CUSTOMER_POINTS:
                        {
                            await LoyaltyOperations.ViewCustomerPointsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kBACK:
                        {
                            await CustomersPL.StartUpCustomersModule();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kADD_POINTS:
                        {
                            await LoyaltyOperations.AddPointsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kREDEEM_POINTS:
                        {
                            await LoyaltyOperations.RedeemPointsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kTOP_LOYALTY_CUSTOMERS:
                        {
                            await LoyaltyOperations.GetTopLoyaltyCustomersAsync();
                            break;

                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kLOYALTY_STATISTICS:
                        {
                            await LoyaltyOperations.GetLoyaltyStatisticsAsync();
                            break;
                        }
                }


                Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }



    }
}