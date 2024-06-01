// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus.Events;

public class KeyPressedEventArgs(KeyCombination keyCombination) : EventArgs
{
    public KeyCombination HotKey { get; } = keyCombination;
}
