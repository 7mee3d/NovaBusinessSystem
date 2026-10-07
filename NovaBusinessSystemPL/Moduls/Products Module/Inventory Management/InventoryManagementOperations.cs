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

        public static async Task AddStockAsync()
        {
            try
            {
                Console.Clear();

                int productID = InputHelper.ReadTheID(
                    "➕ ADD STOCK",
                    "Enter Product ID: "
                );

                Console.Write(
                    $"{ConsoleHelper.GenarateTabs(7)}Quantity To Add : ");

                int quantityToAdd;

                while (!int.TryParse(
                           Console.ReadLine(),
                           out quantityToAdd) ||
                       quantityToAdd <= 0)
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Invalid! Quantity To Add : ");
                }


                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");


                var respone =
                    await httpClient.PatchAsync(
                        $"{productID}/Add?quantity={quantityToAdd}",
                        null
                    );


                if (respone.IsSuccessStatusCode)
                {
                    AddStockResultDTO? result =
                        await respone.Content
                            .ReadFromJsonAsync<AddStockResultDTO>();

                    if (result == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ STOCK NOT ADDED",
                            "Failed to read stock result.");

                        return;
                    }


                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║             ✅ STOCK ADDED                   ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product       : {result.ProductName,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Previous      : {result.PreviousStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Added         : {result.AddedStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ New Stock     : {result.NewStock,-28} ║");

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
                    "❌ STOCK NOT ADDED",
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


        public static async Task RemoveStockAsync()
        {
            try
            {
                Console.Clear();

                int productID = InputHelper.ReadTheID(
                    "➖ REMOVE STOCK",
                    "Enter Product ID: "
                );

                Console.Write(
                    $"{ConsoleHelper.GenarateTabs(7)}Quantity To Remove : ");

                int quantityToRemove;

                while (!int.TryParse(
                           Console.ReadLine(),
                           out quantityToRemove) ||
                       quantityToRemove <= 0)
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Invalid! Quantity To Remove : ");
                }


                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");


                var respone =
                    await httpClient.PatchAsync(
                        $"{productID}/Remove?quantity={quantityToRemove}",
                        null
                    );


                if (respone.IsSuccessStatusCode)
                {
                    RemoveStockResultDTO? result =
                        await respone.Content
                            .ReadFromJsonAsync<RemoveStockResultDTO>();

                    if (result == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ STOCK NOT REMOVED",
                            "Failed to read stock result.");

                        return;
                    }


                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║            ✅ STOCK REMOVED                  ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product       : {result.ProductName,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Previous      : {result.PreviousStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Removed       : {result.RemovedStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ New Stock     : {result.NewStock,-28} ║");

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
                    "❌ STOCK NOT REMOVED",
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

        public static async Task AdjustStockAsync()
        {
            try
            {
                Console.Clear();

                int productID = InputHelper.ReadTheID(
                    "🔧 STOCK ADJUSTMENT",
                    "Enter Product ID: "
                );

                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");

                // Get current system stock
                var stockResponse =
                    await httpClient.GetAsync($"{productID}");

                if (stockResponse.StatusCode ==
                    System.Net.HttpStatusCode.NotFound)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ PRODUCT NOT FOUND",
                        $"Product with ID {productID} was not found."
                    );

                    return;
                }

                if (!stockResponse.IsSuccessStatusCode)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ FAILED TO GET STOCK",
                        await stockResponse.Content.ReadAsStringAsync()
                    );

                    return;
                }

                ProductStockDTO? productStock =
                    await stockResponse.Content
                        .ReadFromJsonAsync<ProductStockDTO>();

                if (productStock == null)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ FAILED TO GET STOCK",
                        "Failed to read product stock."
                    );

                    return;
                }

                Console.WriteLine();
                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}System Stock      : {productStock.StockQuantity}"
                );

                Console.Write(
                    $"{ConsoleHelper.GenarateTabs(7)}Actual Stock      : "
                );

                int actualStock;

                while (!int.TryParse(
                           Console.ReadLine(),
                           out actualStock) ||
                       actualStock < 0)
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Invalid! Actual Stock      : "
                    );
                }

                int difference =
                    actualStock - productStock.StockQuantity;

                Console.WriteLine();
                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}Difference        : {difference}"
                );

                Console.WriteLine();
                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}Adjust stock from " +
                    $"{productStock.StockQuantity} to {actualStock}?"
                );

                Console.Write(
                    $"\n{ConsoleHelper.GenarateTabs(7)}Y / N: "
                );

                string? confirmation =
                    Console.ReadLine()?.Trim().ToUpper();

                if (confirmation != "Y")
                {
                    Console.WriteLine(
                        $"\n{ConsoleHelper.GenarateTabs(7)}Adjustment cancelled."
                    );

                    return;
                }

                var respone =
                    await httpClient.PatchAsync(
                        $"{productID}/Adjust?actualStock={actualStock}",
                        null
                    );

                if (respone.IsSuccessStatusCode)
                {
                    AdjustStockResultDTO? result =
                        await respone.Content
                            .ReadFromJsonAsync<AdjustStockResultDTO>();

                    if (result == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ STOCK NOT ADJUSTED",
                            "Failed to read adjustment result."
                        );

                        return;
                    }

                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}Previous Stock : {result.PreviousStock}"
                    );

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}Actual Stock   : {result.ActualStock}"
                    );

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}Adjustment     : {result.Adjustment}"
                    );

                    Console.WriteLine();

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}✅ STOCK ADJUSTED"
                    );

                    return;
                }

                if (respone.StatusCode ==
                    System.Net.HttpStatusCode.NotFound)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ PRODUCT NOT FOUND",
                        $"Product with ID {productID} was not found."
                    );

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage(
                    "❌ STOCK NOT ADJUSTED",
                    await respone.Content.ReadAsStringAsync()
                );
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again."
                );
            }
        }
    }
}