using System.Net.Http.Json;
using nHelpersPL;
using NovaBusinessSystem.BL;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.Enumeration;

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
            Console.Write($"{HelperPL.GenarateTabs(7)}║  2. Customer Spending Summary            ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  3. Customer Favorite Products           ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  4. Customer Monthly Purchases           ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  5. Customer Ranking                     ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝\n\n");

        }

        private static async Task _GetPurchaseHistory()
        {
            try
            {
                int ID = Globals.ReadTheID();

                if (ID > 0)
                {
                    HelperPL.PrintHeader("🛒 PURCHASE HISTORY", 7);
                    System.Console.WriteLine("\n\n");
                    CustomersBL? customer = CustomersBL.Find(ID)!;

                    if (customer is not null)
                    {
                        HttpClient httpClient = new HttpClient();

                        httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomerPurchases/");

                        var respone = await httpClient.GetAsync($"{ID}");
                        if (respone.IsSuccessStatusCode)
                        {
                            var L_PurchaseHistoryCustomer = await respone.Content.ReadFromJsonAsync<List<CustomerPurchaseDTO>>();

                            if (!L_PurchaseHistoryCustomer!.Any() || L_PurchaseHistoryCustomer!.Count == 0)
                            {
                                HelperPL.ShowNotFoundMessage("⚠️ NO PURCHASE HISTORY ", "This customer has no purchase history.");
                                return;
                            }

                            Console.WriteLine($"{HelperPL.GenarateTabs(5)}{"Sale ID",-15} {"Date",-20} {"Amount",-15} {"Payment",-15} {"Status",-15}");
                            Console.Write($"{HelperPL.GenarateTabs(5)}{new string('-', 80)}{Environment.NewLine}");

                            foreach (var item in L_PurchaseHistoryCustomer!)
                                Console.WriteLine($"{HelperPL.GenarateTabs(5)}{item.SaleID,-15} {item.SaleDate,-20} {item.Amount.ToString("C"),-15} {item.PaymentMethod,-15} {item.Status,-15}");

                            Console.Write($"{HelperPL.GenarateTabs(5)}{new string('-', 80)}{Environment.NewLine}");

                            return;
                        }

                        HelperPL.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

                    }

                    else
                        HelperPL.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");

                }
                else
                    HelperPL.ShowNotFoundMessage("❌ ERROR", "Invalid Data Customer ID");
            }

            catch (Exception ex)
            {
                HelperPL.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        private static async Task _GetCustomerSpendingSummary()
        {
            try
            {
                int ID = Globals.ReadTheID();

                if (ID > 0)
                {
                    HelperPL.PrintHeader("💰 CUSTOMER SPENDING", 7);
                    System.Console.WriteLine("\n\n");
                    CustomersBL? customer = CustomersBL.Find(ID)!;

                    if (customer is not null)
                    {
                        HttpClient httpClient = new HttpClient();

                        httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomerPurchases/");

                        var respone = await httpClient.GetAsync($"{ID}/SpendingSummary");
                        if (respone.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"{HelperPL.GenarateTabs(7)}{"Customer ",-15} : {customer?.FullName}");

                            var customerSpendingSummary = await respone.Content.ReadFromJsonAsync<CustomerSpendingSummaryDTO>();

                            if (customerSpendingSummary is null)
                            {
                                HelperPL.ShowNotFoundMessage("⚠️ NO PURCHASE HISTORY ", "This customer has no purchase history.");
                                return;
                            }
                            System.Console.WriteLine("\n\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║       💰 CUSTOMER SPENDING SUMMARY       ║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║ Total Orders   : {customerSpendingSummary.TotalOrders,-24}║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║ Completed      : {customerSpendingSummary.Completed,-24}║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║ Pending        : {customerSpendingSummary.Pending,-24}║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║ Cancelled      : {customerSpendingSummary.Cancelled,-24}║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║ Total Spent    : {"$" +customerSpendingSummary.TotalSpent,-24}║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║ Average Order  : {"$" +customerSpendingSummary.AverageOrder,-24}║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║ Largest Order  : {"$" +customerSpendingSummary.LargestOrder,-24}║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║ First Purchase : {customerSpendingSummary.FirstPurchase,-24}║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}║ Last Purchase  : {customerSpendingSummary.LastPurchase,-24}║\n");
                            Console.Write($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
                            return;
                        }

                        HelperPL.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

                    }

                    else
                        HelperPL.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");

                }
                else
                    HelperPL.ShowNotFoundMessage("❌ ERROR", "Invalid Data Customer ID");
            }

            catch (Exception ex)
            {
                HelperPL.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task StartupPurchasesCustomers()
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
                    case Enumerations.EnChoicesCustomerPurchases._kBACK:
                        {
                            await CustomersPL.StartUpCustomersModule();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kPURCHASE_HISTORY:
                        {
                            await _GetPurchaseHistory();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kCUSTOMER_SPENDING_SUMMARY:
                        {
                            await _GetCustomerSpendingSummary();
                            break;
                        }

                }


                Console.WriteLine($"\n\n{HelperPL.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}