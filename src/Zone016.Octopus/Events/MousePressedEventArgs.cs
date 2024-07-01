// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus.Events;

public class MousePressedEventArgs(MouseCombination mouseCombination) : EventArgs
{
    public MouseCombination MouseCombination { get; } = mouseCombination;
}

