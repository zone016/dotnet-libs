// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus.Interfaces;

public interface IMouseManager : IDisposable
{
    /// <summary>
    /// Occurs when a registered mouse button and modifier combination is pressed.
    /// </summary>
    event EventHandler<MousePressedEventArgs>? MousePressed;

    /// <summary>
    /// Starts the mouse manager, setting up the necessary hooks.
    /// </summary>
    void Start();

    /// <summary>
    /// Stops the mouse manager, removing the hooks.
    /// </summary>
    void Stop();

    /// <summary>
    /// Registers a mouse button and modifier combination to be monitored.
    /// </summary>
    /// <param name="modifiers">The modifier keys that need to be pressed.</param>
    /// <param name="button">The mouse button that needs to be pressed.</param>
    void RegisterMouse(Modifiers modifiers, MouseButtons button);
}
