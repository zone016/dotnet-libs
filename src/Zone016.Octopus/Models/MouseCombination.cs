// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus.Models;

public class MouseCombination(int id, Modifiers modifiers, MouseButtons button)
{
    public int Id { get; } = id;
    public Modifiers Modifiers { get; } = modifiers;
    public MouseButtons Button { get; } = button;
}
