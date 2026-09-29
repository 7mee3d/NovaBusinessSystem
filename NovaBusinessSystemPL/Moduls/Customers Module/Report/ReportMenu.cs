using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystemPL.Modules.Customers;

namespace NovaBusinessSystem.Modules.Customers.Reports
{

    public class ReportMenu
    {
        private static void _PrintReportMenu()
        {
            System.Console.WriteLine("\n\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║             📊 CUSTOMER REPORT           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  1. 👥 Customer Status Summary           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  2. 🌍 Customers By City                 ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  3. ⭐ Loyalty Summary                   ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  4. 📅 Registration Summary              ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  5. 📈 Customer Growth                   ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  6. 🔥 Customer Activity Report          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
        }


        public static async Task StartupReportSection()
        {
            while (true)
            {
                Console.Clear();
                _PrintReportMenu();
                Console.Write($"\n\n{ConsoleHelper.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 6)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Incorrect choice try agian : ");

                switch ((Enumerations.EnChoicesCustomerReport)choice)
                {

                    case Enumerations.EnChoicesCustomerReport._kBACK:
                        {
                            await CustomersPL.StartUpCustomersModule();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerReport._kCUSTOMER_STATUS_SUMMARY:
                        {
                            await ReportOperations.GetCustomerStatusSummaryAsync();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerReport._kCUSTOMERS_BY_CITY:
                        {
                            await ReportOperations.GetCustomersByCityAsync();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerReport._kLOYALTY_SUMMARY:
                        {
                            await ReportOperations.GetLoyaltySummaryReportAsync();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerReport._kREGISTRATION_SUMMARY :
                        {
                            await ReportOperations.GetRegistrationSummaryAsync() ;
                            break;
                        }
                }


                Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }

    }
}