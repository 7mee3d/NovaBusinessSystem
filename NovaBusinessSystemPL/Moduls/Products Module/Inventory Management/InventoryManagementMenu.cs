using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;

namespace NovaBusinessSystem.Modules.Products.Inventory
{
    public class InventoryManagementMenu
    {
        private static void _PrintInventoryManagementMenu()
        {
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║          📦 INVENTORY MANAGEMENT             ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  1. 📦 View Product Stock                    ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  2. ➕ Add Stock                             ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  3. ➖ Remove Stock                          ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  4. 🔧 Adjust Stock                          ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  5. ⚠️  Low Stock Products                    ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  6. ❌ Out Of Stock Products                 ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  7. 💰 Inventory Value                       ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  8. 📊 Stock Statistics                      ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                                  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");
        }


        public static async Task StartupInventoryManagementSection()
        {
            while (true)
            {
                Console.Clear();

                _PrintInventoryManagementMenu();

                Console.Write(
                    $"\n\n{ConsoleHelper.GenarateTabs(7)}Select: ");

                byte choice = 0;

                while (!byte.TryParse(Console.ReadLine(), out choice) ||
                       choice > 8)
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Incorrect choice try again : ");
                }


                switch ((Enumerations.EnChoicesInventoryManagement)choice)
                {
                    case Enumerations.EnChoicesInventoryManagement._kVIEW_PRODUCT_STOCK:
                    {
                        await InventoryOperations.ViewProductStockAsync();
                        break;
                    }

                    case Enumerations.EnChoicesInventoryManagement._kADD_STOCK:
                    {
                        break;
                    }

                    case Enumerations.EnChoicesInventoryManagement._kREMOVE_STOCK:
                    {
                        break;
                    }

                    case Enumerations.EnChoicesInventoryManagement._kADJUST_STOCK:
                    {
                        break;
                    }

                    case Enumerations.EnChoicesInventoryManagement._kLOW_STOCK_PRODUCTS:
                    {
                        break;
                    }

                    case Enumerations.EnChoicesInventoryManagement._kOUT_OF_STOCK_PRODUCTS:
                    {
                        break;
                    }

                    case Enumerations.EnChoicesInventoryManagement._kINVENTORY_VALUE:
                    {
                        break;
                    }

                    case Enumerations.EnChoicesInventoryManagement._kSTOCK_STATISTICS:
                    {
                        break;
                    }

                    case Enumerations.EnChoicesInventoryManagement._kBACK:
                        return;
                }


                Console.WriteLine(
                    $"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");

                Console.ReadKey();
            }
        }
    }
}