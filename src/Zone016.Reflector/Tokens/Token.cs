// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.
namespace Zone016.Reflector.Tokens;

public class Token(TokenType type, string value, int position)
{
    public TokenType Type { get; protected set; } = type;
    public string Value { get; protected set; } = value;
    public int Position { get; protected set; } = position;
}
