using NovaBusinessSystem.Modules.Products;
using NovaBusinessSystemPL.Modules.Customers;

namespace NovaBusinessSystem

{

    public class Program
    {

        private static async Task Main(string[] args)
        {
                

               //EmployeesPL.EmployeesPL.StartupEmployeesModule();
           // await CustomersPL.StartUpCustomersModule();
           await  ProductsMenu.StartupProductsSection();
        }

    }
}