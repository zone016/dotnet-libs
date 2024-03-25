namespace Zone016.Printer;

/// <summary>
/// Logger is a static helper class that provides a simple way to log messages of different levels.
/// </summary>
public static class Logger
{
    /// <summary>
    /// Prints a message to a specific TextWriter with color formatting.
    /// </summary>
    /// <param name="prefix">The prefix appears before the message.
    /// It's usually used to define the level of the message.</param>
    /// <param name="message">The actual message to be logged.</param>
    /// <param name="prefixColor">The color of the prefix in the output.</param>
    /// <param name="writer">The TextWriter where you want to write the message.
    /// If not present, the message is written to the Console.</param>
    public static void Print(string prefix, string message, ConsoleColor prefixColor, TextWriter? writer = default)
    {
        ForegroundColor = prefixColor;

        if (writer is null)
        {
            Write(prefix);
            ResetColor();

            WriteLine(message);

            return;
        }

        writer.Write(prefix);
        ResetColor();

        writer.WriteLine(message);
    }

    /// <summary>
    /// Prints a success message in green color.
    /// </summary>
    /// <param name="message">The actual success message to be logged.</param>
    public static void PrintSuccess(string message)
    {
        Print("suc: ", message, ConsoleColor.Green);
    }

    /// <summary>
    /// Prints an informational message in dark gray color.
    /// </summary>
    /// <param name="message">The informational message to be logged.</param>
    public static void PrintInformational(string message)
    {
        Print("inf: ", message, ConsoleColor.DarkGray);
    }

    /// <summary>
    /// Prints a warning message in yellow color.
    /// </summary>
    /// <param name="message">The warning message to be logged.</param>
    public static void PrintWarning(string message)
    {
        Print("war: ", message, ConsoleColor.Yellow);
    }

    /// <summary>
    /// Prints an error message in red color.
    /// </summary>
    /// <param name="message">The error message to be logged.</param>
    public static void PrintError(string message)
    {
        Print("err: ", message, ConsoleColor.Red, Error);
    }
}
