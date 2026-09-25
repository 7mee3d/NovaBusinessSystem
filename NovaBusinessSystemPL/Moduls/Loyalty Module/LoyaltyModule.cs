
using System.Net.Http.Json;
using nHelpersPL;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.PL
{

    public class Loyalty
    {

        private static void _PrintMenuLoyaltyPoints()
        {
            System.Console.WriteLine("\n\n\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║            ⭐ LOYALTY POINTS             ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  1. View Customer Points                 ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  2. Add Points                           ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  3. Redeem Points                        ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  4. Top Loyalty Customers                ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  5. Loyalty Statistics                   ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
            Console.Write($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝\n\n\n");


        }

        private static async Task ViewCustomerPointsAsync()
        {
            try
            {
                int id = Globals.ReadTheID();
                System.Console.WriteLine("\n\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Customers/");

                var response = await httpClient.GetAsync($"LoyaltyPoints/{id}");


                if (response.IsSuccessStatusCode)
                {
                    var jsonCustomer =
                        await response.Content.ReadFromJsonAsync<CustomerPointsDTO>();

                    if (jsonCustomer is not null)
                    {
                        Console.Write($"{HelperPL.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║             ⭐ CUSTOMER POINTS           ║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Customer ID    : {jsonCustomer.CustomerID,-24}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Customer Name  : {jsonCustomer.CustomerName,-24}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Current Points : {jsonCustomer.CurrentPoints,-24}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Loyalty Level  : {jsonCustomer.LoyaltyLevel,-24}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
                    }
                }
                else
                {


                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        System.Console.Write($"{HelperPL.GenarateTabs(7)}");
                        Console.Write(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                HelperPL.ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
            }
        }

        private static async Task _AddPointsAsync()
        {

            try
            {
                int ID = Globals.ReadTheID()!;

                if (ID > 0)
                {

                    int pointsToAdd = 0;

                    System.Console.WriteLine("\n\n");
                    HelperPL.PrintHeader("⭐ ADD POINTS", 7);
                    System.Console.WriteLine("\n\n");
                    System.Console.Write($"{HelperPL.GenarateTabs(7)}Points To Add  : ");

                    while (!int.TryParse(Console.ReadLine(), out pointsToAdd) || pointsToAdd <= 0)
                        System.Console.WriteLine($"{HelperPL.GenarateTabs(7)}Invalid Data Try Add valid points : ");

                    HttpClient httpClient = new HttpClient();

                    httpClient.BaseAddress = new Uri("http://localhost:5276/api/Customers/");

                    var respone = await httpClient.PostAsync($"LoyaltyPoints/{ID}/{pointsToAdd}", null);

                    if (respone.IsSuccessStatusCode)
                    {

                        var content = await respone.Content.ReadFromJsonAsync<PointsTransactionResultDTO>();
                        System.Console.WriteLine("\n\n");

                        Console.Write($"{HelperPL.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║          ✅ POINTS ADDED                 ║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Customer      : {content.CustomerName,-25}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Previous      : {content.PreviousPoints,-25}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Added         : {content.Points,-25}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ New Balance   : {content.NewBalance,-25}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");

                        return;

                    }

                    HelperPL.ShowNotFoundMessage("❌ POINTS DEDUCTED", $"{await respone.Content.ReadAsStringAsync()}");
                }
                else
                    HelperPL.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");
            }
            catch (Exception ex)
            {
                HelperPL.ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
            }
        }

        private static async Task _RedeemPointsAsync()
        {

            try
            {
                int ID = Globals.ReadTheID()!;

                if (ID > 0)
                {

                    int pointsToAdd = 0;
                    System.Console.WriteLine("\n\n");
                    HelperPL.PrintHeader("🎁 REDEEM POINTS", 7);
                    System.Console.WriteLine("\n\n");
                    System.Console.Write($"{HelperPL.GenarateTabs(7)}Points To Redeem  : ");

                    while (!int.TryParse(Console.ReadLine(), out pointsToAdd) || pointsToAdd <= 0)
                        System.Console.WriteLine($"{HelperPL.GenarateTabs(7)}Invalid Data Try Add valid points : ");

                    HttpClient httpClient = new HttpClient();

                    httpClient.BaseAddress = new Uri("http://localhost:5276/api/Customers/");

                    var respone = await httpClient.PatchAsync($"LoyaltyPoints/{ID}/{pointsToAdd}", null);

                    if (respone.IsSuccessStatusCode)
                    {
                        var content = await respone.Content.ReadFromJsonAsync<PointsTransactionResultDTO>();

                        System.Console.WriteLine("\n\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║            ✅ POINTS REDEEMED            ║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Customer      : {content.CustomerName,-25}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Previous      : {content.PreviousPoints,-25}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Redeemed      : {content.Points,-25}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ New Balance   : {content.NewBalance,-25}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");

                        return;

                    }

                    HelperPL.ShowNotFoundMessage("❌ INSUFFICIENT POINTS", $"{await respone.Content.ReadAsStringAsync()}");
                }
                else
                    HelperPL.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");
            }
            catch (Exception ex)
            {
                HelperPL.ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
            }
        }

        private static async Task _GetTopLoyaltyCustomersAsync()
        {

            try
            {

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/Customers/LoyaltyPoints/");

                var respone = await httpClient.GetAsync("TopCustomers/");
                Console.Clear();

                HelperPL.PrintHeader("🏆 TOP LOYALTY CUSTOMERS", 7);
                if (respone.IsSuccessStatusCode)
                {
                    var topLoyaltyCustomerPoints = await respone.Content.ReadFromJsonAsync<List<TopLoyaltyCustomerDTO>>();
                    if (topLoyaltyCustomerPoints is not null)
                    {
                        System.Console.WriteLine($"\n\n{HelperPL.GenarateTabs(6)}{"Rank",-15} {"Customer Name",-25} {"Points",-15} {"Level",-15}");
                        System.Console.WriteLine($"{HelperPL.GenarateTabs(6)}{new string('-', 70)}");


                        foreach (var item in topLoyaltyCustomerPoints)
                            System.Console.WriteLine($"{HelperPL.GenarateTabs(6)}{item.Rank,-15} {item.CustomerName,-25} {item.Points,-15} {item.Level,-15}");

                        System.Console.WriteLine($"{HelperPL.GenarateTabs(6)}{new string('-', 70)}");

                    }

                    return;
                }

                HelperPL.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }
            catch (Exception ex)
            {
                HelperPL.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");
            }

        }

        private static async Task _GetLoyaltyStatisticsAsync()
        {

            try
            {

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/Customers/LoyaltyPoints/");

                var respone = await httpClient.GetAsync("LoyaltyStatistics/");
                Console.Clear();
                System.Console.WriteLine("\n\n\n");
                HelperPL.PrintHeader("⭐ LOYALTY STATISTICS", 7);

                if (respone.IsSuccessStatusCode)
                {
                    var loyaltyStatistics = await respone.Content.ReadFromJsonAsync<LoyaltyStatisticsDTO>();

                    if (loyaltyStatistics is not null)
                    {
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Total Loyalty Points : {loyaltyStatistics.TotalLoyaltyPoints,-18}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Minimum Points       : {loyaltyStatistics.MinimumPoints,-18}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Maximum Points       : {loyaltyStatistics.MaximumPoints,-18}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Average Points       : {loyaltyStatistics.AveragePoints,-18:F2}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Diamond Customers    : {loyaltyStatistics.DiamondCustomers,-18}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Platinum Customers   : {loyaltyStatistics.PlatinumCustomers,-18}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Gold Customers       : {loyaltyStatistics.GoldCustomers,-18}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Silver Customers     : {loyaltyStatistics.SilverCustomers,-18}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}║ Bronze Customers     : {loyaltyStatistics.BronzeCustomers,-18}║\n");
                        Console.Write($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
                    }

                    return;
                }

                HelperPL.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }
            catch (Exception ex)
            {
                HelperPL.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");
            }

        }

        public static async Task StartUpLoyaltyPointsSection()
        {
            while (true)
            {

                Console.Clear();
                _PrintMenuLoyaltyPoints();

                Console.Write($"{HelperPL.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 5)
                    Console.Write($"{HelperPL.GenarateTabs(7)}Invalid Choive Select another choice : ");

                switch ((Enumerations.EnChoicesLoyaltyPoints)choice)
                {
                    case Enumerations.EnChoicesLoyaltyPoints._kVIEW_CUSTOMER_POINTS:
                        {
                            await ViewCustomerPointsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kBACK:
                        {
                            await CustomersPL.StartUpCustomersModule();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kADD_POINTS:
                        {
                            await _AddPointsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kREDEEM_POINTS:
                        {
                            await _RedeemPointsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kTOP_LOYALTY_CUSTOMERS:
                        {
                            await _GetTopLoyaltyCustomersAsync();
                            break;

                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kLOYALTY_STATISTICS:
                        {
                            await _GetLoyaltyStatisticsAsync();
                            break;
                        }
                }


                Console.WriteLine($"\n\n{HelperPL.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }



    }
}