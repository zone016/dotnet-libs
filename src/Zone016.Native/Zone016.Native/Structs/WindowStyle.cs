// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Structs;

/// <summary>
/// Window styles for creating windows.
/// </summary>
[Flags]
public enum WindowStyle : uint
{
    /// <summary>
    /// The window has a thin-line border.
    /// </summary>
    Border = 0x00800000,

    /// <summary>
    /// The window has a title bar (includes the Border style).
    /// </summary>
    Caption = 0x00C00000,

    /// <summary>
    /// The window is a child window. A window with this style cannot have a menu bar.
    /// </summary>
    Child = 0x40000000,

    /// <summary>
    /// Same as the Child style.
    /// </summary>
    ChildWindow = 0x40000000,

    /// <summary>
    /// Excludes the area occupied by child windows when drawing occurs within the parent window.
    /// </summary>
    ClipChildren = 0x02000000,

    /// <summary>
    /// Clips child windows relative to each other.
    /// </summary>
    ClipSiblings = 0x04000000,

    /// <summary>
    /// The window is initially disabled. A disabled window cannot receive input from the user.
    /// </summary>
    Disabled = 0x08000000,

    /// <summary>
    /// The window has a border of a style typically used with dialog boxes.
    /// </summary>
    DialogFrame = 0x00400000,

    /// <summary>
    /// The window is the first control of a group of controls.
    /// </summary>
    Group = 0x00020000,

    /// <summary>
    /// The window has a horizontal scroll bar.
    /// </summary>
    HorizontalScroll = 0x00100000,

    /// <summary>
    /// The window is initially minimized. Same as the Minimize style.
    /// </summary>
    Iconic = 0x20000000,

    /// <summary>
    /// The window is initially maximized.
    /// </summary>
    Maximize = 0x01000000,

    /// <summary>
    /// The window has a maximize button.
    /// </summary>
    MaximizeBox = 0x00010000,

    /// <summary>
    /// The window is initially minimized. Same as the Iconic style.
    /// </summary>
    Minimize = 0x20000000,

    /// <summary>
    /// The window has a minimize button.
    /// </summary>
    MinimizeBox = 0x00020000,

    /// <summary>
    /// The window is an overlapped window. An overlapped window has a title bar and a border.
    /// </summary>
    Overlapped = 0x00000000,

    /// <summary>
    /// The window is a pop-up window.
    /// </summary>
    Popup = 0x80000000,

    /// <summary>
    /// The window has a sizing border. Same as the ThickFrame style.
    /// </summary>
    SizeBox = 0x00040000,

    /// <summary>
    /// The window has a window menu on its title bar. The Caption style must also be specified.
    /// </summary>
    SystemMenu = 0x00080000,

    /// <summary>
    /// The window is a control that can receive the keyboard focus when the user presses the TAB key.
    /// </summary>
    TabStop = 0x00010000,

    /// <summary>
    /// The window has a sizing border. Same as the SizeBox style.
    /// </summary>
    ThickFrame = 0x00040000,

    /// <summary>
    /// The window is initially visible.
    /// </summary>
    Visible = 0x10000000,

    /// <summary>
    /// The window has a vertical scroll bar.
    /// </summary>
    VerticalScroll = 0x00200000,

    /// <summary>
    /// The window accepts drag-drop files.
    /// </summary>
    AcceptFiles = 0x00000010,

    /// <summary>
    /// Forces a top-level window onto the taskbar when the window is visible.
    /// </summary>
    AppWindow = 0x00040000,

    /// <summary>
    /// The window has a border with a sunken edge.
    /// </summary>
    ClientEdge = 0x00000200,

    /// <summary>
    /// Paints all descendants of a window in bottom-to-top painting order using double-buffering.
    /// </summary>
    Composited = 0x02000000,

    /// <summary>
    /// The title bar of the window includes a question mark.
    /// </summary>
    ContextHelp = 0x00000400,

    /// <summary>
    /// The window contains child windows that should take part in dialog box navigation.
    /// </summary>
    ControlParent = 0x00010000,

    /// <summary>
    /// The window has a double border; the window can, optionally, be created with a title bar.
    /// </summary>
    DialogModalFrame = 0x00000001,

    /// <summary>
    /// The window is a layered window.
    /// </summary>
    Layered = 0x00080000,

    /// <summary>
    /// The horizontal origin of the window is on the right edge.
    /// </summary>
    LayoutRtl = 0x00400000,

    /// <summary>
    /// The window has generic left-aligned properties. This is the default.
    /// </summary>
    Left = 0x00000000,

    /// <summary>
    /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar is to the left of the client area.
    /// </summary>
    LeftScrollbar = 0x00004000,

    /// <summary>
    /// The window text is displayed using left-to-right reading-order properties. This is the default.
    /// </summary>
    LtrReading = 0x00000000,

    /// <summary>
    /// The window is a MDI child window.
    /// </summary>
    MdiChild = 0x00000040,

    /// <summary>
    /// A top-level window created with this style does not become the foreground window when the user clicks it.
    /// </summary>
    NoActivate = 0x08000000,

    /// <summary>
    /// The window does not pass its window layout to its child windows.
    /// </summary>
    NoInheritLayout = 0x00100000,

    /// <summary>
    /// The child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
    /// </summary>
    NoParentNotify = 0x00000004,

    /// <summary>
    /// The window does not render to a redirection surface.
    /// </summary>
    NoRedirectionBitmap = 0x00200000,

    /// <summary>
    /// The window has generic right-aligned properties.
    /// </summary>
    Right = 0x00001000,

    /// <summary>
    /// The vertical scroll bar is to the right of the client area. This is the default.
    /// </summary>
    RightScrollbar = 0x00000000,

    /// <summary>
    /// The window text is displayed using right-to-left reading-order properties.
    /// </summary>
    RtlReading = 0x00002000,

    /// <summary>
    /// The window has a three-dimensional border style intended to be used for items that do not accept user input.
    /// </summary>
    StaticEdge = 0x00020000,

    /// <summary>
    /// The window is intended to be used as a floating toolbar.
    /// </summary>
    ToolWindow = 0x00000080,

    /// <summary>
    /// The window should be placed above all non-topmost windows and should stay above them.
    /// </summary>
    TopMost = 0x00000008,

    /// <summary>
    /// The window should not be painted until siblings beneath the window have been painted.
    /// </summary>
    Transparent = 0x00000020,

    /// <summary>
    /// The window has a border with a raised edge.
    /// </summary>
    WindowEdge = 0x00000100
}
