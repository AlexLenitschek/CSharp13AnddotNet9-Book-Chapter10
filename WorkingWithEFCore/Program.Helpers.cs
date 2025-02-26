using System.Globalization;

partial class Program
{
    private static void ConfigureConsole(string culture = "en-US", bool useComputerCulture = false)
    {
        // To enable Unicode characters like the Euro Symvol in the console.
        OutputEncoding = System.Text.Encoding.UTF8;

        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"Current Culture: {CultureInfo.CurrentCulture.DisplayName}");
    }

    private static void WriteLineInColor(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = color;
        WriteLine(text);
        ForegroundColor = previousColor;
    }

    private static void SectionTitle(string title)
    {
        WriteLineInColor(text: $"*** {title} ***", color: ConsoleColor.DarkYellow);
    }

    private static void Fail(string message)
    {
        WriteLineInColor($"Fail > {message}", ConsoleColor.Red);
    }

    private static void Info(string message)
    {
        WriteLineInColor($"Info > {message}", ConsoleColor.Cyan);
    }
}