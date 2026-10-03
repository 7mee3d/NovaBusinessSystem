using System.Net.Http.Json;
using NovaBusinessSystem.BL.Products;
using NovaBusinessSystem.DTOs.Products;
using NovaBusinessSystem.Enumeration;
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
                        $"{ConsoleHelper.GenarateTabs(4)}{"ID",-15} {"Product",-25} {"Category",-18} {"Price",-15} {"Stock",-10} {"Status",-12}");

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(4)}{new string('-', 101)}{Environment.NewLine}");

                    foreach (var item in L_Products)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(4)}{item.ProductID,-15} " +
                            $"{item.ProductName,-25} " +
                            $"{item.Category,-18} " +
                            $"{item.Price.ToString("N2"),-15} " +
                            $"{item.StockQuantity,-10} " +
                            $"{item.Status,-12}");
                    }

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(4)}{new string('-', 101)}{Environment.NewLine}");

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

        public static async Task GetProductByIDAsync()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("🔎 GET PRODUCT BY ID", 7);
                Console.WriteLine("\n\n");

                int productID = InputHelper.ReadTheID("🔎 GET PRODUCT BY ID", "Enter Product ID: ");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/");

                var respone = await httpClient.GetAsync($"{productID}");

                if (respone.IsSuccessStatusCode)
                {
                    var product =
                        await respone.Content.ReadFromJsonAsync<ProductDTO>();

                    if (product is null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ PRODUCT NOT FOUND",
                            "No product was found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║              📦 PRODUCT DETAILS              ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product ID       : {product.ProductID,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product Name     : {product.ProductName,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Category         : {product.Category,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Price            : {product.Price.ToString("N2"),-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Stock Quantity   : {product.StockQuantity,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Status           : {product.Status,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage(
                    "❌ PRODUCT NOT FOUND",
                    $"Product with ID {productID} was not found.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }

        public static async Task AddNewProductAsync()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n");

                ConsoleHelper.PrintHeader("➕ ADD PRODUCT", 7);

                Console.WriteLine("\n");

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Product Name      : ");

                string productName = Console.ReadLine()!;

                while (true)
                {
                    bool isPass = true;

                    if (string.IsNullOrWhiteSpace(productName))
                        isPass = false;
                    else
                    {
                        foreach (char c in productName)
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                            {
                                isPass = false;
                                break;
                            }
                    }

                    if (!isPass)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Product Name      : "}: ");
                        productName = Console.ReadLine()!;
                    }
                    else
                        break;
                }


                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Category          : ");
                string category = Console.ReadLine()!;

                while (true)
                {
                    bool isPass = true;

                    if (string.IsNullOrWhiteSpace(category))
                        isPass = false;
                    else
                    {
                        foreach (char c in category)
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                            {
                                isPass = false;
                                break;
                            }
                    }

                    if (!isPass)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Category          : "}: ");
                        category = Console.ReadLine()!;
                    }
                    else
                        break;
                }

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Price             : ");
                decimal price = 0.0m;

                while (!Decimal.TryParse(Console.ReadLine(), out price))
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Price          : "}: ");

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Initial Stock     : ");

                int stockQuantity = 0;

                while (!int.TryParse(Console.ReadLine(), out stockQuantity))
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Stock Quantity          : "}: ");

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Status            : ");
                string status = Console.ReadLine()!;

                while (true)
                {
                    bool isPass = true;

                    if (string.IsNullOrWhiteSpace(status))
                        isPass = false;
                    else
                    {
                        foreach (char c in status)
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                            {
                                isPass = false;
                                break;
                            }
                    }

                    if (!isPass)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Status            : ",-16}: ");
                        status = Console.ReadLine()!;
                    }
                    else
                        break;
                }

                ProductRequestDTO productRequest = new ProductRequestDTO(
                    productName,
                    category,
                    price,
                    stockQuantity,
                    status
                );


                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/");


                var respone =
                    await httpClient.PostAsJsonAsync("", productRequest);


                if (respone.IsSuccessStatusCode)
                {
                    ProductDTO? product =
                        await respone.Content.ReadFromJsonAsync<ProductDTO>();

                    if (product == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ PRODUCT NOT ADDED",
                            "Failed to read the created product.");

                        return;
                    }


                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║             ✅ PRODUCT ADDED                 ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product ID       : {product.ProductID,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product Name     : {product.ProductName,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Category         : {product.Category,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Price            : {product.Price.ToString("N2"),-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Initial Stock    : {product.StockQuantity,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Status           : {product.Status,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }


                ConsoleHelper.ShowNotFoundMessage(
                    "❌ PRODUCT NOT ADDED",
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
