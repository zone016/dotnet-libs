// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Enums;

/// <summary>
/// Modifiers for hotkey combinations.
/// </summary>
[Flags]
public enum Modifiers
{
    None = 0x0000,
    Alt = 0x0001,
    Control = 0x0002,
    NoRepeat = 0x4000,
    Shift = 0x0004,
    Win = 0x0008
}
