// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Enums;

public enum WindowLongIndex
{
    /// <summary>
    /// Retrieves the extended window styles.
    /// </summary>
    ExtendedStyle = -20,

    /// <summary>
    /// Retrieves a handle to the application instance.
    /// </summary>
    InstanceHandle = -6,

    /// <summary>
    /// Retrieves a handle to the parent window, if any.
    /// </summary>
    ParentHandle = -8,

    /// <summary>
    /// Retrieves the window identifier.
    /// </summary>
    WindowId = -12,

    /// <summary>
    /// Retrieves the window styles.
    /// </summary>
    Style = -16,

    /// <summary>
    /// Retrieves the user data associated with the window.
    /// </summary>
    UserData = -21,

    /// <summary>
    /// Retrieves the pointer to the window procedure, or a handle representing the address of the window procedure.
    /// </summary>
    WindowProcedure = -4
}
