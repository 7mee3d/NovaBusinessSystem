
using System.Net.Http.Json;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.Helpers;

namespace NovaBusinessSystem.Modules.Customers.Loyalty
{

    public class LoyaltyOperations
    {


        public static async Task ViewCustomerPointsAsync()
        {
            try
            {
                int id = InputHelper.ReadTheID();
                System.Console.WriteLine("\n\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Loyalty/");

                var response = await httpClient.GetAsync($"{id}");


                if (response.IsSuccessStatusCode)
                {
                    var jsonCustomer =
                        await response.Content.ReadFromJsonAsync<CustomerPointsDTO>();

                    if (jsonCustomer is not null)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║             ⭐ CUSTOMER POINTS           ║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Customer ID    : {jsonCustomer.CustomerID,-24}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Customer Name  : {jsonCustomer.CustomerName,-24}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Current Points : {jsonCustomer.CurrentPoints,-24}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Loyalty Level  : {jsonCustomer.LoyaltyLevel,-24}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
                    }
                }
                else
                {


                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}");
                        Console.Write(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
            }
        }

        public static async Task AddPointsAsync()
        {

            try
            {
                int ID = InputHelper.ReadTheID()!;

                if (ID > 0)
                {

                    int pointsToAdd = 0;

                    System.Console.WriteLine("\n\n");
                    ConsoleHelper.PrintHeader("⭐ ADD POINTS", 7);
                    System.Console.WriteLine("\n\n");
                    System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Points To Add  : ");

                    while (!int.TryParse(Console.ReadLine(), out pointsToAdd) || pointsToAdd <= 0)
                        System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}Invalid Data Try Add valid points : ");

                    HttpClient httpClient = new HttpClient();

                    httpClient.BaseAddress = new Uri("http://localhost:5276/api/Loyalty/");

                    var respone = await httpClient.PostAsync($"{ID}/{pointsToAdd}", null);

                    if (respone.IsSuccessStatusCode)
                    {

                        var content = await respone.Content.ReadFromJsonAsync<PointsTransactionResultDTO>();
                        System.Console.WriteLine("\n\n");

                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║          ✅ POINTS ADDED                 ║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Customer      : {content.CustomerName,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Previous      : {content.PreviousPoints,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Added         : {content.Points,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ New Balance   : {content.NewBalance,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");

                        return;

                    }

                    ConsoleHelper.ShowNotFoundMessage("❌ POINTS DEDUCTED", $"{await respone.Content.ReadAsStringAsync()}");
                }
                else
                    ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
            }
        }

        public static async Task RedeemPointsAsync()
        {

            try
            {
                int ID = InputHelper.ReadTheID()!;

                if (ID > 0)
                {

                    int pointsToAdd = 0;
                    System.Console.WriteLine("\n\n");
                    ConsoleHelper.PrintHeader("🎁 REDEEM POINTS", 7);
                    System.Console.WriteLine("\n\n");
                    System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Points To Redeem  : ");

                    while (!int.TryParse(Console.ReadLine(), out pointsToAdd) || pointsToAdd <= 0)
                        System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}Invalid Data Try Add valid points : ");

                    HttpClient httpClient = new HttpClient();

                    httpClient.BaseAddress = new Uri("http://localhost:5276/api/Loyalty/");

                    var respone = await httpClient.PatchAsync($"{ID}/{pointsToAdd}", null);

                    if (respone.IsSuccessStatusCode)
                    {
                        var content = await respone.Content.ReadFromJsonAsync<PointsTransactionResultDTO>();

                        System.Console.WriteLine("\n\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║            ✅ POINTS REDEEMED            ║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Customer      : {content.CustomerName,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Previous      : {content.PreviousPoints,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Redeemed      : {content.Points,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ New Balance   : {content.NewBalance,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");

                        return;

                    }

                    ConsoleHelper.ShowNotFoundMessage("❌ INSUFFICIENT POINTS", $"{await respone.Content.ReadAsStringAsync()}");
                }
                else
                    ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
            }
        }

        public static async Task GetTopLoyaltyCustomersAsync()
        {

            try
            {

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/Loyalty/");

                var respone = await httpClient.GetAsync("TopCustomers/");
                Console.Clear();

                ConsoleHelper.PrintHeader("🏆 TOP LOYALTY CUSTOMERS", 7);
                if (respone.IsSuccessStatusCode)
                {
                    var topLoyaltyCustomerPoints = await respone.Content.ReadFromJsonAsync<List<TopLoyaltyCustomerDTO>>();
                    if (topLoyaltyCustomerPoints is not null)
                    {
                        System.Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(6)}{"Rank",-15} {"Customer Name",-25} {"Points",-15} {"Level",-15}");
                        System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(6)}{new string('-', 70)}");


                        foreach (var item in topLoyaltyCustomerPoints)
                            System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(6)}{item.Rank,-15} {item.CustomerName,-25} {item.Points,-15} {item.Level,-15}");

                        System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(6)}{new string('-', 70)}");

                    }

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");
            }

        }

        public static async Task GetLoyaltyStatisticsAsync()
        {

            try
            {

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/Loyalty/");

                var respone = await httpClient.GetAsync("Statistics/");
                Console.Clear();
                System.Console.WriteLine("\n\n\n");
                ConsoleHelper.PrintHeader("⭐ LOYALTY STATISTICS", 7);

                if (respone.IsSuccessStatusCode)
                {
                    var loyaltyStatistics = await respone.Content.ReadFromJsonAsync<LoyaltyStatisticsDTO>();

                    if (loyaltyStatistics is not null)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Total Loyalty Points : {loyaltyStatistics.TotalLoyaltyPoints,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Minimum Points       : {loyaltyStatistics.MinimumPoints,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Maximum Points       : {loyaltyStatistics.MaximumPoints,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Average Points       : {loyaltyStatistics.AveragePoints,-18:F2}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Diamond Customers    : {loyaltyStatistics.DiamondCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Platinum Customers   : {loyaltyStatistics.PlatinumCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Gold Customers       : {loyaltyStatistics.GoldCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Silver Customers     : {loyaltyStatistics.SilverCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Bronze Customers     : {loyaltyStatistics.BronzeCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
                    }

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