
using NovaBusinessSystem.PL;

namespace NovaBusinessSystem

{

    public class Program
    {

        private static async Task Main(string[] args)
        {
                

               //EmployeesPL.EmployeesPL.StartupEmployeesModule();
            await CustomersPL.StartUpCustomersModule();
        }

    }
}