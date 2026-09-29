using System.Net.Http.Json;
using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.BL.Customers;

namespace NovaBusinessSystem.Modules.Customers.Purchases
{

    public static class PurchasesOperations
    {
       
        public static async Task GetPurchaseHistory()
        {
            try
            {
                int ID = InputHelper.ReadTheID();

                if (ID > 0)
                {
                    ConsoleHelper.PrintHeader("🛒 PURCHASE HISTORY", 7);
                    System.Console.WriteLine("\n\n");
                    CustomersBL? customer = CustomersBL.Find(ID)!;

                    if (customer is not null)
                    {
                        HttpClient httpClient = new HttpClient();

                        httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersPurchases/");

                        var respone = await httpClient.GetAsync($"{ID}");

                        if (respone.IsSuccessStatusCode)
                        {
                            var L_PurchaseHistoryCustomer = await respone.Content.ReadFromJsonAsync<List<CustomerPurchaseDTO>>();

                            if (!L_PurchaseHistoryCustomer!.Any() || L_PurchaseHistoryCustomer!.Count == 0)
                            {
                                ConsoleHelper.ShowNotFoundMessage("⚠️ NO PURCHASE HISTORY ", "This customer has no purchase history.");
                                return;
                            }

                            Console.WriteLine($"{ConsoleHelper.GenarateTabs(5)}{"Sale ID",-15} {"Date",-20} {"Amount",-15} {"Payment",-15} {"Status",-15}");
                            Console.Write($"{ConsoleHelper.GenarateTabs(5)}{new string('-', 80)}{Environment.NewLine}");

                            foreach (var item in L_PurchaseHistoryCustomer!)
                                Console.WriteLine($"{ConsoleHelper.GenarateTabs(5)}{item.SaleID,-15} {item.SaleDate,-20} {item.Amount.ToString("C"),-15} {item.PaymentMethod,-15} {item.Status,-15}");

                            Console.Write($"{ConsoleHelper.GenarateTabs(5)}{new string('-', 80)}{Environment.NewLine}");

                            return;
                        }

                        ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

                    }

                    else
                        ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");

                }
                else
                    ConsoleHelper.ShowNotFoundMessage("❌ ERROR", "Invalid Data Customer ID");
            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task GetCustomerSpendingSummary()
        {
            try
            {
                int ID = InputHelper.ReadTheID();

                if (ID > 0)
                {
                    ConsoleHelper.PrintHeader("💰 CUSTOMER SPENDING", 7);
                    System.Console.WriteLine("\n\n");
                    CustomersBL? customer = CustomersBL.Find(ID)!;

                    if (customer is not null)
                    {
                        HttpClient httpClient = new HttpClient();

                        httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersPurchases/");

                        var respone = await httpClient.GetAsync($"{ID}/SpendingSummary");
                        if (respone.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}{"Customer ",-15} : {customer?.FullName}");

                            var customerSpendingSummary = await respone.Content.ReadFromJsonAsync<CustomerSpendingSummaryDTO>();

                            if (customerSpendingSummary is null)
                            {
                                ConsoleHelper.ShowNotFoundMessage("⚠️ NO PURCHASE HISTORY ", "This customer has no purchase history.");
                                return;
                            }
                            System.Console.WriteLine("\n\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║       💰 CUSTOMER SPENDING SUMMARY       ║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Total Orders   : {customerSpendingSummary.TotalOrders,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Completed      : {customerSpendingSummary.Completed,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Pending        : {customerSpendingSummary.Pending,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Cancelled      : {customerSpendingSummary.Cancelled,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Total Spent    : {"$" + customerSpendingSummary.TotalSpent,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Average Order  : {"$" + customerSpendingSummary.AverageOrder,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Largest Order  : {"$" + customerSpendingSummary.LargestOrder,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ First Purchase : {customerSpendingSummary.FirstPurchase,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Last Purchase  : {customerSpendingSummary.LastPurchase,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
                            return;
                        }

                        ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

                    }

                    else
                        ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");

                }
                else
                    ConsoleHelper.ShowNotFoundMessage("❌ ERROR", "Invalid Data Customer ID");
            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task GetCustomerMonthlyPurchases()
        {
            try
            {

                Console.Clear();
                System.Console.WriteLine("\n\n\n");
                ConsoleHelper.PrintHeader("📅 MONTHLY PURCHASE SUMMARY", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersPurchases/");

                var respone = await httpClient.GetAsync($"MonthlyPurchases");
                if (respone.IsSuccessStatusCode)
                {

                    var monthlyPurchases = await respone.Content.ReadFromJsonAsync<List<MonthlyPurchaseDTO>>();
                    if (monthlyPurchases == null || !monthlyPurchases.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO PURCHASE DATA",
                            "No monthly purchase data found.");

                        return;
                    }
                    System.Console.WriteLine("\n\n");
                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}{"Month",-20} {"Orders",-15} {"Total Spent",-25}");

                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}{new string('-', 55)}{Environment.NewLine}");

                    foreach (var item in monthlyPurchases)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(7)}{item.Month,-20} {item.Orders,-15} {item.TotalSpent.ToString("C"),-25}");
                    }

                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}{new string('-', 55)}{Environment.NewLine}");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");


            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task GetCustomersRankingAsync()
        {
            try
            {

                Console.Clear();
                System.Console.WriteLine("\n\n\n");
                ConsoleHelper.PrintHeader("🏆 CUSTOMER RANKING", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersPurchases/");

                var respone = await httpClient.GetAsync($"CustomersRanking");
                if (respone.IsSuccessStatusCode)
                {

                    var customersRanking = await respone.Content.ReadFromJsonAsync<List<CustomerRankingDTO>>();
                    if (customersRanking == null || !customersRanking.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO PURCHASE DATA",
                            "No monthly purchase data found.");

                        return;
                    }
                    System.Console.WriteLine("\n\n");
                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(6)}{"Rank",-15} {"Customer",-30} {"Orders",-10} {"Spending",-25}");

                    Console.Write($"{ConsoleHelper.GenarateTabs(6)}{new string('-', 70)}{Environment.NewLine}");

                    foreach (var item in customersRanking)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(6)}{item.Rank,-15} {item.FullName,-30} {item.Orders,-10} {item.Spending.ToString("C"),-25}");
                    }

                    Console.Write($"{ConsoleHelper.GenarateTabs(6)}{new string('-', 70)}{Environment.NewLine}");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");


            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }
    
    }
}