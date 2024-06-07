// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Typer;

/// <summary>
/// Logger is a static helper class that provides a simple way to log messages of different levels.
/// </summary>
public static class Printer
{
    private const char OpenTag = '[';
    private const char CloseTag = ']';

    private static readonly string[] s_operations = 
        [
            "bold", "b",
            "italic", "i"
        ];

    private static readonly Dictionary<string, string> s_colorAliases = new()
    {
        { "black", "#000000" },
        { "red", "#FF0000" },
        { "green", "#00FF00" },
        { "yellow", "#FFFF00" },
        { "blue", "#0000FF" },
        { "magenta", "#FF00FF" },
        { "cyan", "#00FFFF" },
        { "white", "#FFFFFF" },
        { "gray", "#808080" },
        { "dark-gray", "#A9A9A9" },
        { "dark-red", "#8B0000" },
        { "dark-green", "#006400" },
        { "dark-yellow", "#FFD700" },
        { "dark-blue", "#00008B" },
        { "dark-magenta", "#8B008B" },
        { "dark-cyan", "#008B8B" }
    };

    private static void WriteSegment(string text, TextWriter? writer = default)
    {
        if (writer is null)
        {
            System.Console.Write(text);
            return;
        }

        writer.Write(text);
    }

    public static void Print(string message, bool sanitize = true, TextWriter? writer = default)
    {
        message = sanitize ? Sanitize(message) : message;

        var openTags = new Stack<string>();
        var index = 0;

        while (index < message.Length)
        {
            if (message[index] == OpenTag)
            {
                var closingBracketIndex = message.IndexOf(CloseTag, index);
                if (closingBracketIndex == -1)
                {
                    ResetColor();
                    throw new InvalidPrinterExpressionException("Unclosed tag detected.");
                }

                var tag = message[(index + 1)..closingBracketIndex].Trim();
                if (tag.StartsWith('/'))
                {
                    // Closing tag
                    while (openTags.Count > 0)
                    {
                        var lastTag = openTags.Pop();
                        if (lastTag.StartsWith('#') || s_colorAliases.ContainsKey(lastTag.ToLower()))
                        {
                            ResetColor();
                        }

                        else switch (lastTag)
                        {
                            case "bold" or "b":
                                ResetBold(writer);
                                break;
                            case "italic" or "i":
                                ResetItalic(writer);
                                break;
                        }
                    }
                }
                else
                {
                    // Opening tag
                    var tags = tag.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var t in tags)
                    {
                        var openingTagName = t.Trim().ToLowerInvariant();
                        var isHexColorTag = openingTagName.StartsWith('#') && openingTagName.Length == 7;
                        var isAliasColorTag = s_colorAliases.ContainsKey(openingTagName);
                        var isOtherTag = s_operations.Contains(openingTagName);

                        if (!isHexColorTag && !isAliasColorTag && !isOtherTag)
                        {
                            ResetColor();
                            throw new InvalidPrinterExpressionException($"Invalid tag name: {openingTagName}.");
                        }

                        openTags.Push(openingTagName);
                        if (isHexColorTag || isAliasColorTag)
                        {
                            var color = isAliasColorTag ? s_colorAliases[openingTagName] : openingTagName;
                            ApplyHexColor(color, writer);
                        }
                        
                        if (!isOtherTag) continue;
                        switch (openingTagName)
                        {
                            case "bold" or "b":
                                ApplyBold(writer);
                                break;
                            case "italic" or "i":
                                ApplyItalic(writer);
                                break;
                        }
                    }
                }

                index = closingBracketIndex + 1;
            }
            else
            {
                var nextTagIndex = message.IndexOf(OpenTag, index);
                if (nextTagIndex == -1)
                {
                    WriteSegment(message[index..], writer);
                    break;
                }

                WriteSegment(message[index..nextTagIndex], writer);
                index = nextTagIndex;
            }
        }

        if (openTags.Count > 0)
        {
            ResetColor();
            throw new InvalidPrinterExpressionException("Unclosed tags remain at the end of the message.");
        }

        if (writer is null)
        {
            WriteLine();
            return;
        }

        writer.WriteLine();
    }

    private static void ApplyHexColor(string hexColor, TextWriter? writer)
    {
        var colorCode = $"\x1b[38;2;{HexToRgb(hexColor)}m";
        if (writer is null)
        {
            System.Console.Write(colorCode);
            return;
        }

        writer.Write(colorCode);
    }

    private static string HexToRgb(string hex)
    {
        var r = int.Parse(hex.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
        var g = int.Parse(hex.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
        var b = int.Parse(hex.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
        return $"{r};{g};{b}";
    }

    private static void ApplyBold(TextWriter? writer)
    {
        const string BoldCode = "\x1b[1m";
        if (writer is null)
        {
            System.Console.Write(BoldCode);
            return;
        }

        writer.Write(BoldCode);
    }
    
    private static void ResetBold(TextWriter? writer)
    {
        const string ResetCode = "\x1b[22m"; // Reset bold
        if (writer is null)
        {
            System.Console.Write(ResetCode);
            return;
        }

        writer.Write(ResetCode);
    }
    
    private static void ApplyItalic(TextWriter? writer)
    {
        const string ItalicCode = "\x1b[3m";
        if (writer is null)
        {
            System.Console.Write(ItalicCode);
            return;
        }

        writer.Write(ItalicCode);
    }
    
    private static void ResetItalic(TextWriter? writer)
    {
        const string ResetCode = "\x1b[23m"; // Reset italic
        if (writer is null)
        {
            System.Console.Write(ResetCode);
            return;
        }

        writer.Write(ResetCode);
    }

    private static void ResetColor() => System.Console.Write("\x1b[39m");

    public static string Sanitize(string message)
    {
        var sanitized = message
            .Replace("[", string.Empty)
            .Replace("]", string.Empty);
        
        return sanitized;
    }

    public static void WriteSuccess(string message, bool sanitize = true)
    {
        message = sanitize ? Sanitize(message) : message;
        Print($"[b green]suc:[/] {message}");
    }

    public static void Write(string message, bool sanitize = true)
    {
        message = sanitize ? Sanitize(message) : message;
        Print($"[b dark-gray]inf:[/] {message}");
    }

    public static void WriteWarning(string message, bool sanitize = true)
    {
        message = sanitize ? Sanitize(message) : message;
        Print($"[b i yellow]war[/][yellow]:[/] {message}");
    }

    public static void WriteError(string message, bool sanitize = true)
    {
        message = sanitize ? Sanitize(message) : message;
        Print($"[b i red]err[/][red]:[/] {message}", writer: Error);
    }
}
