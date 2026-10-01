using System.Net.Http.Json;
using NovaBusinessSystem.DTOs.Products;
using NovaBusinessSystem.Helpers;

namespace NovaBusinessSystem.Modules.Products
{
    public class ProductsOperations
    {
        public static async Task GetAllProductsAsync()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("📋 PRODUCT LIST", 7);
                Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/");

                var respone = await httpClient.GetAsync("");

                if (respone.IsSuccessStatusCode)
                {
                    var L_Products =
                        await respone.Content.ReadFromJsonAsync<List<ProductDTO>>();

                    if (L_Products == null || !L_Products.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO PRODUCTS FOUND",
                            "No products were found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(4)}{"ID",-6} {"Product",-25} {"Category",-18} {"Price",-15} {"Stock",-10} {"Status",-12}");

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(4)}{new string('-', 92)}{Environment.NewLine}");

                    foreach (var item in L_Products)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(4)}{item.ProductID,-6} " +
                            $"{item.ProductName,-25} " +
                            $"{item.Category,-18} " +
                            $"{item.Price.ToString("N2"),-15} " +
                            $"{item.StockQuantity,-10} " +
                            $"{item.Status,-12}");
                    }

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(4)}{new string('-', 92)}{Environment.NewLine}");

                    Console.WriteLine(
                        $"\n\n{ConsoleHelper.GenarateTabs(4)}Total Products: {L_Products.Count}");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage(
                    "⚠️ NO DATA FOUND",
                    $"{await respone.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }
    }
}
