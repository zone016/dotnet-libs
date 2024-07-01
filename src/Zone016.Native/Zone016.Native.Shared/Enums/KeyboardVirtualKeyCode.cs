// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Enums;

/// <summary>
/// Virtual key codes for keyboard keys.
/// <para>Only cover ANSI keys.</para>
/// </summary>
public enum KeyboardVirtualKeyCode
{
    /// <summary>
    /// Control-break processing.
    /// </summary>
    Cancel = 0x03,

    /// <summary>
    /// Middle mouse button (three-button mouse).
    /// </summary>
    MiddleButton = 0x04,

    /// <summary>
    /// BACKSPACE key.
    /// </summary>
    Backspace = 0x08,

    /// <summary>
    /// TAB key.
    /// </summary>
    Tab = 0x09,

    /// <summary>
    /// CLEAR key.
    /// </summary>
    Clear = 0x0C,

    /// <summary>
    /// ENTER key.
    /// </summary>
    Enter = 0x0D,

    /// <summary>
    /// SHIFT key.
    /// </summary>
    Shift = 0x10,

    /// <summary>
    /// CTRL key.
    /// </summary>
    Control = 0x11,

    /// <summary>
    /// ALT key.
    /// </summary>
    Alt = 0x12,

    /// <summary>
    /// PAUSE key.
    /// </summary>
    Pause = 0x13,

    /// <summary>
    /// CAPS LOCK key.
    /// </summary>
    CapsLock = 0x14,

    /// <summary>
    /// ESC key.
    /// </summary>
    Escape = 0x1B,

    /// <summary>
    /// SPACEBAR key.
    /// </summary>
    Space = 0x20,

    /// <summary>
    /// PAGE UP key.
    /// </summary>
    PageUp = 0x21,

    /// <summary>
    /// PAGE DOWN key.
    /// </summary>
    PageDown = 0x22,

    /// <summary>
    /// END key.
    /// </summary>
    End = 0x23,

    /// <summary>
    /// HOME key.
    /// </summary>
    Home = 0x24,

    /// <summary>
    /// LEFT ARROW key.
    /// </summary>
    LeftArrow = 0x25,

    /// <summary>
    /// UP ARROW key.
    /// </summary>
    UpArrow = 0x26,

    /// <summary>
    /// RIGHT ARROW key.
    /// </summary>
    RightArrow = 0x27,

    /// <summary>
    /// DOWN ARROW key.
    /// </summary>
    DownArrow = 0x28,

    /// <summary>
    /// SELECT key.
    /// </summary>
    Select = 0x29,

    /// <summary>
    /// PRINT key.
    /// </summary>
    Print = 0x2A,

    /// <summary>
    /// EXECUTE key.
    /// </summary>
    Execute = 0x2B,

    /// <summary>
    /// PRINT SCREEN key.
    /// </summary>
    PrintScreen = 0x2C,

    /// <summary>
    /// INS key.
    /// </summary>
    Insert = 0x2D,

    /// <summary>
    /// DEL key.
    /// </summary>
    Delete = 0x2E,

    /// <summary>
    /// HELP key.
    /// </summary>
    Help = 0x2F,

    /// <summary>
    /// 0 key.
    /// </summary>
    Key0 = 0x30,

    /// <summary>
    /// 1 key.
    /// </summary>
    Key1 = 0x31,

    /// <summary>
    /// 2 key.
    /// </summary>
    Key2 = 0x32,

    /// <summary>
    /// 3 key.
    /// </summary>
    Key3 = 0x33,

    /// <summary>
    /// 4 key.
    /// </summary>
    Key4 = 0x34,

    /// <summary>
    /// 5 key.
    /// </summary>
    Key5 = 0x35,

    /// <summary>
    /// 6 key.
    /// </summary>
    Key6 = 0x36,

    /// <summary>
    /// 7 key.
    /// </summary>
    Key7 = 0x37,

    /// <summary>
    /// 8 key.
    /// </summary>
    Key8 = 0x38,

    /// <summary>
    /// 9 key.
    /// </summary>
    Key9 = 0x39,

    /// <summary>
    /// A key.
    /// </summary>
    KeyA = 0x41,

    /// <summary>
    /// B key.
    /// </summary>
    KeyB = 0x42,

    /// <summary>
    /// C key.
    /// </summary>
    KeyC = 0x43,

    /// <summary>
    /// D key.
    /// </summary>
    KeyD = 0x44,

    /// <summary>
    /// E key.
    /// </summary>
    KeyE = 0x45,

    /// <summary>
    /// F key.
    /// </summary>
    KeyF = 0x46,

    /// <summary>
    /// G key.
    /// </summary>
    KeyG = 0x47,

    /// <summary>
    /// H key.
    /// </summary>
    KeyH = 0x48,

    /// <summary>
    /// I key.
    /// </summary>
    KeyI = 0x49,

    /// <summary>
    /// J key.
    /// </summary>
    KeyJ = 0x4A,

    /// <summary>
    /// K key.
    /// </summary>
    KeyK = 0x4B,

    /// <summary>
    /// L key.
    /// </summary>
    KeyL = 0x4C,

    /// <summary>
    /// M key.
    /// </summary>
    KeyM = 0x4D,

    /// <summary>
    /// N key.
    /// </summary>
    KeyN = 0x4E,

    /// <summary>
    /// O key.
    /// </summary>
    KeyO = 0x4F,

    /// <summary>
    /// P key.
    /// </summary>
    KeyP = 0x50,

    /// <summary>
    /// Q key.
    /// </summary>
    KeyQ = 0x51,

    /// <summary>
    /// R key.
    /// </summary>
    KeyR = 0x52,

    /// <summary>
    /// S key.
    /// </summary>
    KeyS = 0x53,

    /// <summary>
    /// T key.
    /// </summary>
    KeyT = 0x54,

    /// <summary>
    /// U key.
    /// </summary>
    KeyU = 0x55,

    /// <summary>
    /// V key.
    /// </summary>
    KeyV = 0x56,

    /// <summary>
    /// W key.
    /// </summary>
    KeyW = 0x57,

    /// <summary>
    /// X key.
    /// </summary>
    KeyX = 0x58,

    /// <summary>
    /// Y key.
    /// </summary>
    KeyY = 0x59,

    /// <summary>
    /// Z key.
    /// </summary>
    KeyZ = 0x5A,

    /// <summary>
    /// Left Windows key.
    /// </summary>
    LeftWindows = 0x5B,

    /// <summary>
    /// Right Windows key.
    /// </summary>
    RightWindows = 0x5C,

    /// <summary>
    /// Applications key.
    /// </summary>
    Applications = 0x5D,

    /// <summary>
    /// Sleep key.
    /// </summary>
    Sleep = 0x5F,

    /// <summary>
    /// Numeric keypad 0 key.
    /// </summary>
    Numpad0 = 0x60,

    /// <summary>
    /// Numeric keypad 1 key.
    /// </summary>
    Numpad1 = 0x61,

    /// <summary>
    /// Numeric keypad 2 key.
    /// </summary>
    Numpad2 = 0x62,

    /// <summary>
    /// Numeric keypad 3 key.
    /// </summary>
    Numpad3 = 0x63,

    /// <summary>
    /// Numeric keypad 4 key.
    /// </summary>
    Numpad4 = 0x64,

    /// <summary>
    /// Numeric keypad 5 key.
    /// </summary>
    Numpad5 = 0x65,

    /// <summary>
    /// Numeric keypad 6 key.
    /// </summary>
    Numpad6 = 0x66,

    /// <summary>
    /// Numeric keypad 7 key.
    /// </summary>
    Numpad7 = 0x67,

    /// <summary>
    /// Numeric keypad 8 key.
    /// </summary>
    Numpad8 = 0x68,

    /// <summary>
    /// Numeric keypad 9 key.
    /// </summary>
    Numpad9 = 0x69,

    /// <summary>
    /// Multiply key.
    /// </summary>
    Multiply = 0x6A,

    /// <summary>
    /// Add key.
    /// </summary>
    Add = 0x6B,

    /// <summary>
    /// Separator key.
    /// </summary>
    Separator = 0x6C,

    /// <summary>
    /// Subtract key.
    /// </summary>
    Subtract = 0x6D,

    /// <summary>
    /// Decimal key.
    /// </summary>
    Decimal = 0x6E,

    /// <summary>
    /// Divide key.
    /// </summary>
    Divide = 0x6F,

    /// <summary>
    /// F1 key.
    /// </summary>
    F1 = 0x70,

    /// <summary>
    /// F2 key.
    /// </summary>
    F2 = 0x71,

    /// <summary>
    /// F3 key.
    /// </summary>
    F3 = 0x72,

    /// <summary>
    /// F4 key.
    /// </summary>
    F4 = 0x73,

    /// <summary>
    /// F5 key.
    /// </summary>
    F5 = 0x74,

    /// <summary>
    /// F6 key.
    /// </summary>
    F6 = 0x75,

    /// <summary>
    /// F7 key.
    /// </summary>
    F7 = 0x76,

    /// <summary>
    /// F8 key.
    /// </summary>
    F8 = 0x77,

    /// <summary>
    /// F9 key.
    /// </summary>
    F9 = 0x78,

    /// <summary>
    /// F10 key.
    /// </summary>
    F10 = 0x79,

    /// <summary>
    /// F11 key.
    /// </summary>
    F11 = 0x7A,

    /// <summary>
    /// F12 key.
    /// </summary>
    F12 = 0x7B,

    /// <summary>
    /// NUM LOCK key.
    /// </summary>
    NumLock = 0x90,

    /// <summary>
    /// SCROLL LOCK key.
    /// </summary>
    ScrollLock = 0x91,

    /// <summary>
    /// Left SHIFT key.
    /// </summary>
    LeftShift = 0xA0,

    /// <summary>
    /// Right SHIFT key.
    /// </summary>
    RightShift = 0xA1,

    /// <summary>
    /// Left CONTROL key.
    /// </summary>
    LeftControl = 0xA2,

    /// <summary>
    /// Right CONTROL key.
    /// </summary>
    RightControl = 0xA3,

    /// <summary>
    /// Left MENU key.
    /// </summary>
    LeftMenu = 0xA4,

    /// <summary>
    /// Right MENU key.
    /// </summary>
    RightMenu = 0xA5
}
