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
                ConsoleHelper.PrintHeader("👥 CUSTOMER STATUS" , 7 ); 
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/");

                var respone = await httpClient.GetAsync($"CustomersReport");

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
    }


}