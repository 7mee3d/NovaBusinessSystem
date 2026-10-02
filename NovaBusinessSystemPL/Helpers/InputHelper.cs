namespace NovaBusinessSystem.Helpers
{
    public static class InputHelper
    {

        public static int ReadTheID(string? Title, string? Message)
        {
            Console.Clear();
            System.Console.WriteLine("\n\n\n");

            ConsoleHelper.PrintHeader(Title, 7);
            System.Console.WriteLine("\n\n");
            System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}{Message}");
            int ID = -1;
            while (!int.TryParse(Console.ReadLine(), out ID))
                System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Invalid Data ID : ");

            System.Console.WriteLine("\n\n");


            return ID;
        }
    }
}