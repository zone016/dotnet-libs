// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Delegates;

/// <summary>
/// Delegate for the window procedure.
/// </summary>
/// <param name="hwnd">Handle to the window.</param>
/// <param name="msg">Message identifier.</param>
/// <param name="wParam">Additional message information.</param>
/// <param name="lParam">Additional message information.</param>
/// <returns>The result of the message processing.</returns>
public delegate IntPtr WndProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);
