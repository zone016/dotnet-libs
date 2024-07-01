// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

using Zone016.Native.Shared.Enums;

namespace Zone016.Octopus.Models;

public record KeyCombination(int Id, Modifiers Modifiers, KeyboardVirtualKeyCode Key)
{
    public readonly int Id = Id;
    public readonly Modifiers Modifiers = Modifiers;
    public readonly KeyboardVirtualKeyCode Key = Key;
}
