// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus.Models;

public record KeyCombination(int Id, Modifiers Modifiers, VirtualKeyCode Key)
{
    public readonly int Id = Id;
    public readonly Modifiers Modifiers = Modifiers;
    public readonly VirtualKeyCode Key = Key;
}
