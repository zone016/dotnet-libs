// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus.Interfaces;

public interface IKeyboardManager : IDisposable
{

    event EventHandler<KeyPressedEventArgs>? KeyPressed;
    IRegistration Register(Modifiers modifiers, KeyboardVirtualKeyCode key);
}
