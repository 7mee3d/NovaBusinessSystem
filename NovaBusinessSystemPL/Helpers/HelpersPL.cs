using System.Reflection.Metadata;

namespace nHelpersPL
{

    public static class HelperPL
    {

        public static string GenarateTabs(int numberTab)
        {
            string Tab = "";

            if (numberTab < 0) return "";

            for (int counter = 1; counter <= numberTab; counter += 1)
                Tab += '\t';

            return Tab;
        }

        private static int GetDisplayWIdth(string Text)
        {
            int width = 0;

            foreach (char character in Text)
            {


                width += char.GetUnicodeCategory(character) switch
                {
                    System.Globalization.UnicodeCategory.OtherSymbol => 2,
                    _ => 1
                };

            }

            return width;
        }

        public static void PrintHeader(string? TitleHeader, int? numberTab)
        {
            if (TitleHeader is null) return;
            if (numberTab is null) return;

            const int BoxBorders = 2;
            int width = 42;
            int contentLength = width - BoxBorders;
            int titleWidth = GetDisplayWIdth(TitleHeader);

            double paddingLeft = Math.Ceiling((contentLength - titleWidth) / 2.0);
            double paddingRight = contentLength - titleWidth - paddingLeft + 2;

            string Tabs = GenarateTabs(numberTab.Value);

            Console.WriteLine($"{Tabs}╔══════════════════════════════════════════╗");
            Console.WriteLine(
                $"{Tabs}║{new string(' ', (int)paddingLeft)}{TitleHeader.Trim()}{new string(' ', (int)paddingRight)}║"
            );
            Console.WriteLine($"{Tabs}╚══════════════════════════════════════════╝");
        }

        public static void PrintHeaderErrors(string? TitleHeader, int? numberTab)
        {
            if (TitleHeader is null) return;
            if (numberTab is null) return;

            const int BoxBorders = 2;
            int width = 72;
            int contentLength = width - BoxBorders;
            int titleWidth = GetDisplayWIdth(TitleHeader);

            double paddingLeft = Math.Ceiling((contentLength - titleWidth) / 2.0);
            double paddingRight = contentLength - titleWidth - paddingLeft + 2;

            string Tabs = GenarateTabs(numberTab.Value);

            Console.WriteLine($"{Tabs}╔════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(
                $"{Tabs}║{new string(' ', (int)paddingLeft)}{TitleHeader.Trim()}{new string(' ', (int)paddingRight)}║"
            );
            Console.WriteLine($"{Tabs}╠════════════════════════════════════════════════════════════════════════╣");
        }

        public static void ReadInformation(string label, int alignmentNumber, int numberTabs)
        {
            Console.Write($"{GenarateTabs(numberTabs)}{label.PadRight(alignmentNumber) + " : "}");
        }

        public static string? ReadTheStringWithoutNumbers(string label, int alignemntNumber, int numberTabs)
        {

            if (alignemntNumber < 0 || numberTabs < 0 || string.IsNullOrWhiteSpace(label))
                return null;

            string text = string.Empty;

            while (true)
            {
                ReadInformation(label, alignemntNumber, numberTabs);
                text = Console.ReadLine()!;
                Console.WriteLine();
                bool isFound = false;

                if (!string.IsNullOrWhiteSpace(text))
                    foreach (char character in text)
                    {
                        if (char.IsDigit(character) || char.IsPunctuation(character) || Char.IsNumber(character) || char.IsSymbol(character) || char.IsWhiteSpace(character))
                        {
                            isFound = true;
                            break;
                        }

                    }


                if (!isFound && !string.IsNullOrWhiteSpace(text))
                    break;
            }

            return text;
        }


        public static T? ReadTheStringWithNumbers<T>(string label, int alignemntNumber, int numberTabs)
        {

            if (alignemntNumber < 0 || numberTabs < 0 || string.IsNullOrWhiteSpace(label))
                return default(T);

            string obj = string.Empty;

            string text = "";
            while (true)
            {
                ReadInformation(label, alignemntNumber, numberTabs);
                text = Console.ReadLine()!;
                Console.WriteLine();

                bool isFound = false;

                foreach (char character in text)
                {
                    if (char.IsLetter(character) || char.IsPunctuation(character) || char.IsSymbol(character))
                    {
                        isFound = true;
                        break;
                    }

                }

                if (!isFound)
                    break;
            }


            return (T)Convert.ChangeType(text, typeof(T));

        }

        public static void ShowNotFoundMessage(string MessageHeader , string MessageBody , string? MessageReason = null )
        {
            System.Console.WriteLine("\n\n");
            PrintHeaderErrors(MessageHeader, 5);
            Console.WriteLine($"{GenarateTabs(5)}║ {MessageBody.Trim(),-50}                     ║");
            if (MessageReason is not null)
                Console.WriteLine($"{GenarateTabs(5)}║ Reason: {MessageReason.Trim(),-50}             ║");
            Console.WriteLine($"{GenarateTabs(5)}╚════════════════════════════════════════════════════════════════════════╝");
        }
        
    }
}