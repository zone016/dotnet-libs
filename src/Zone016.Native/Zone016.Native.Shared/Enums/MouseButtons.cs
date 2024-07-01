// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Enums;

/// <summary>
/// Specifies constants that define which mouse button was pressed.
/// </summary>
public enum MouseButtons
{
    /// <summary>
    /// The left mouse button.
    /// </summary>
    Left = 0x01,

    /// <summary>
    /// The right mouse button.
    /// </summary>
    Right = 0x02,

    /// <summary>
    /// The middle mouse button (usually the wheel button).
    /// </summary>
    Middle = 0x04,

    /// <summary>
    /// The first X button (typically the "back" button on a mouse with additional buttons).
    /// </summary>
    XButton1 = 0x05,

    /// <summary>
    /// The second X button (typically the "forward" button on a mouse with additional buttons).
    /// </summary>
    XButton2 = 0x06
}
