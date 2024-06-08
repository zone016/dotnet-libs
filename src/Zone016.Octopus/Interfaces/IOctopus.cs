// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

using Zone016.Native.Shared.Enums;

namespace Zone016.Octopus.Interfaces;

public interface IHotKeyManager : IDisposable
{

    event EventHandler<KeyPressedEventArgs>? KeyPressed;
    IRegistration Register(Modifiers modifiers, VirtualKeyCode key);
}
