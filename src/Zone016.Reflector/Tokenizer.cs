// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.
using Zone016.Reflector.Tokens;

namespace Zone016.Reflector;

public static class Tokenizer
{
    private static readonly char[] s_separators = [' ', '\r', '\n', '\t'];

    public static List<Token> Tokenize(string input)
    {
        var parts = input.Split(s_separators, StringSplitOptions.RemoveEmptyEntries);

        var tokens = new List<Token>();
        foreach (var part in parts)
        {
            var tokenType = DetermineTokenType(part);
            var token = new Token(tokenType, part, -1);
            tokens.Add(token);
        }

        return tokens;
    }

    private static TokenType DetermineTokenType(string part) => part.ToUpperInvariant() switch
    {
        "SELECT" => TokenType.Select,
        "FROM" => TokenType.From,
        "WHERE" => TokenType.Where,
        "STRING" => TokenType.StringFunction,
        "INT" => TokenType.IntFunction,
        "FLOAT" => TokenType.FloatFunction,
        "LIKE" => TokenType.Like,
        "=" => TokenType.Equals,
        ">" => TokenType.LessThan,
        "<" => TokenType.GreaterThan,
        "<=" => TokenType.LessThanOrEqual,
        ">=" => TokenType.GreaterThanOrEqual,
        "," => TokenType.Comma,
        "(" => TokenType.OpenParenthesis,
        ")" => TokenType.CloseParenthesis,
        _ => TokenType.Unknown
    };
}
