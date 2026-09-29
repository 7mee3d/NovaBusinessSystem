using System.Net.Http.Json;
using NovaBusinessSystem.DTOs.Customers.Reports;
using NovaBusinessSystem.Helpers;

namespace NovaBusinessSystem.Modules.Customers.Reports
{
    public class ReportOperations
    {
        public static async Task GetCustomerStatusSummaryAsync()
        {
            try
            {
                System.Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("👥 CUSTOMER STATUS", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersReport/");

                var respone = await httpClient.GetAsync($"Status");

                if (respone.IsSuccessStatusCode)
                {
                    var L_CustomersStatus =
                                 await respone.Content.ReadFromJsonAsync<List<CustomerStatusDTO>>();

                    if (L_CustomersStatus == null || !L_CustomersStatus.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO CUSTOMER STATUS DATA",
                            "No customer status data was found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}{"Status",-20} {"Customers",-15}");

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

                    foreach (var item in L_CustomersStatus)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(7)}{item.Status,-20} {item.Customers,-15}");
                    }

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }


        public static async Task GetCustomersByCityAsync()
        {
            try
            {
                System.Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("🌍 CUSTOMERS BY CITY", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersReport/");

                var respone = await httpClient.GetAsync($"City");

                if (respone.IsSuccessStatusCode)
                {
                    var L_CustomersByCity =
                        await respone.Content.ReadFromJsonAsync<List<CustomersByCityDTO>>();

                    if (L_CustomersByCity == null || !L_CustomersByCity.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO CUSTOMER CITY DATA",
                            "No customer city data was found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}{"City",-20} {"Customers",-15}");

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

                    foreach (var item in L_CustomersByCity)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(7)}{item.City,-20} {item.Customers,-15}");
                    }

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

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