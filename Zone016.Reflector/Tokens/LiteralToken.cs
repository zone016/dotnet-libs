// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Reflector.Tokens;

public class LiteralToken(TokenType type, string value, int position) : Token(type, value, position);
