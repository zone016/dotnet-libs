// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Enums;

/// <summary>
/// Mouse messages that can be intercepted by a low-level mouse hook.
/// </summary>
public enum MouseMessages
{
    /// <summary>
    /// Posted when the user presses the left mouse button.
    /// </summary>
    LeftButtonDown = 0x0201,
    
    /// <summary>
    /// Posted when the user releases the left mouse button.
    /// </summary>
    LeftButtonUp = 0x0202,
    
    /// <summary>
    /// Posted when the mouse is moved.
    /// </summary>
    MouseMove = 0x0200,
    
    /// <summary>
    /// Posted when the user presses the mouse wheel button and rotates the wheel.
    /// </summary>
    MouseWheel = 0x020A,
    
    /// <summary>
    /// Posted when the user presses the mouse wheel button and rotates the wheel horizontally.
    /// </summary>
    MouseHWheel = 0x020E
}
