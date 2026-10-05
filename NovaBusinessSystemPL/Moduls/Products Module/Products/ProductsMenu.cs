using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;

namespace NovaBusinessSystem.Modules.Products
{
    public class ProductsMenu
    {
        private static void _PrintMainMenuProducts()
        {
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                 📦 PRODUCTS                  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  1. 📋 List Products                         ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  2. 🔎 Get Product By ID                     ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  3. ➕ Add Product                           ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  4. ✏️  Update Product                        ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  5. 🗑️  Delete Product                        ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  6. 🔍 Search & Filter Products              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  7. 📦 Inventory Management                  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  8. 💰 Product Sales Analysis                ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  9. 📊 Product Reports                       ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                                  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

        }


        public static async Task StartupProductsSection()
        {
            while (true)
            {
                Console.Clear();
                _PrintMainMenuProducts();
                Console.Write($"\n\n{ConsoleHelper.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 9)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Incorrect choice try agian : ");

                switch ((Enumerations.EnChoicesProductsModule)choice)
                {

                    case Enumerations.EnChoicesProductsModule._kLIST_PRODUCTS:
                        {
                            await ProductsOperations.GetAllProductsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kGET_PRODUCT_BY_ID:
                        {
                            await ProductsOperations.GetProductByIDAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kADD_PRODUCT:
                        {
                            await ProductsOperations.AddNewProductAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kUPDATE_PRODUCT:
                        {
                            await ProductsOperations.UpdateProductAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kDELETE_PRODUCT:
                        {

                            await ProductsOperations.DeleteProductAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kSEARCH_AND_FILTER_PRODUCTS:
                        break;

                    case Enumerations.EnChoicesProductsModule._kINVENTORY_MANAGEMENT:
                        break;

                    case Enumerations.EnChoicesProductsModule._kPRODUCT_SALES_ANALYSIS:
                        break;

                    case Enumerations.EnChoicesProductsModule._kPRODUCT_REPORTS:
                        break;

                    case Enumerations.EnChoicesProductsModule._kBACK:
                        return;
                }




                Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }



        }
    }
}