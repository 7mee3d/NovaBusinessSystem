
using nHelpersPL;

namespace NovaBusinessSystem.PL
{

    public static class Globals
    {
        public static int ReadTheID()
        {
            Console.Clear();
            System.Console.WriteLine("\n\n\n");

            HelperPL.PrintHeader("🔎 GET CUSTOMER BY ID", 7);
            System.Console.WriteLine("\n\n");
            System.Console.Write($"{HelperPL.GenarateTabs(7)}Enter Customer ID: ");
            int ID = -1;
            while (!int.TryParse(Console.ReadLine(), out ID))
                System.Console.Write($"{HelperPL.GenarateTabs(7)}Invalid Data ID : ");

            System.Console.WriteLine("\n\n");


            return ID;
        }
    }
}