namespace nHelpersPL
{

    public class HelperPL
    {

        protected static string GenarateTabs(int numberTab)
        {
            string Tab = "";

            if (numberTab < 0) return "";

            for (int counter = 1; counter <= numberTab; counter += 1)
                Tab += '\t';

            return Tab;
        }

        private static int GetDisplayWIdth (string Text )
        {
            int width = 0 ;

            foreach(char character in Text)
            {


                width += char.GetUnicodeCategory(character)  switch
                {
                    System.Globalization.UnicodeCategory.OtherSymbol => 2 ,
                    _ => 1 
                };

            }

            return width ; 
        }

        protected static void PrintHeader(string? TitleHeader, int? numberTab)
        {
            if (TitleHeader is null) return;
            if (numberTab is null) return;

            const int BoxBorders = 2;
            int width = 42 ; 
            int contentLength = width - BoxBorders;
            int titleWidth = GetDisplayWIdth(TitleHeader);

            double paddingLeft = Math.Ceiling( (contentLength - titleWidth  ) / 2.0);
            double paddingRight = contentLength - titleWidth- paddingLeft + 2;

            string Tabs = GenarateTabs(numberTab.Value);

            Console.WriteLine($"{Tabs}╔══════════════════════════════════════════╗");
            Console.WriteLine(
                $"{Tabs}║{new string(' ',(int)paddingLeft)}{TitleHeader.Trim()}{new string(' ', (int)paddingRight)}║"
            );
            Console.WriteLine($"{Tabs}╚══════════════════════════════════════════╝");
        }
    }
}