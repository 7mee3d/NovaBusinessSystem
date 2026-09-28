namespace NovaBusinessSystem.Helpers
{
    public static class InputHelper
    {
        public static int ReadTheID()
        {
            Console.Clear();
            System.Console.WriteLine("\n\n\n");

            ConsoleHelper.PrintHeader("🔎 GET CUSTOMER BY ID", 7);
            System.Console.WriteLine("\n\n");
            System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Enter Customer ID: ");
            int ID = -1;
            while (!int.TryParse(Console.ReadLine(), out ID))
                System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Invalid Data ID : ");

            System.Console.WriteLine("\n\n");


            return ID;
        }
    }
}