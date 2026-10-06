using System.Net.Http.Json;
using NovaBusinessSystem.DTOs.Products.Inventory;
using NovaBusinessSystem.Helpers;

namespace NovaBusinessSystem.Modules.Products.Inventory
{
    public class InventoryOperations
    {
        public static async Task ViewProductStockAsync()
        {
            try
            {
                Console.Clear();

                int productID = InputHelper.ReadTheID(
                    "🔎 VIEW PRODUCT STOCK",
                    "Enter Product ID: "
                );


                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");


                var respone =
                    await httpClient.GetAsync($"{productID}");


                if (respone.IsSuccessStatusCode)
                {
                    ProductStockDTO? productStock =
                        await respone.Content
                            .ReadFromJsonAsync<ProductStockDTO>();

                    if (productStock == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ PRODUCT NOT FOUND",
                            $"Product with ID {productID} was not found.");

                        return;
                    }


                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║              📦 PRODUCT STOCK                ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product ID       : {productStock.ProductID,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product Name     : {productStock.ProductName,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Category         : {productStock.Category,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Price            : {productStock.Price.ToString("N2"),-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Stock Quantity   : {productStock.StockQuantity,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Stock Value      : {productStock.StockValue.ToString("N2"),-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Status           : {productStock.Status,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }


                if (respone.StatusCode ==
                    System.Net.HttpStatusCode.NotFound)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ PRODUCT NOT FOUND",
                        $"Product with ID {productID} was not found.");

                    return;
                }


                ConsoleHelper.ShowNotFoundMessage(
                    "❌ REQUEST FAILED",
                    await respone.Content.ReadAsStringAsync());
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