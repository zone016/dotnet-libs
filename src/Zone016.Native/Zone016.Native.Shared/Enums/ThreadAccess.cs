// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Enums;

/// <summary>
/// Defines the access rights for the thread.
/// </summary>
[Flags]
public enum ThreadAccess : int
{
    /// <summary>
    /// Terminate the thread.
    /// </summary>
    Terminate = 0x0001,

    /// <summary>
    /// Suspend or resume the thread.
    /// </summary>
    SuspendResume = 0x0002,

    /// <summary>
    /// Get the context of the thread.
    /// </summary>
    GetContext = 0x0008,

    /// <summary>
    /// Set the context of the thread.
    /// </summary>
    SetContext = 0x0010,

    /// <summary>
    /// Set information for the thread.
    /// </summary>
    SetInformation = 0x0020,

    /// <summary>
    /// Query information of the thread.
    /// </summary>
    QueryInformation = 0x0040,

    /// <summary>
    /// Set the thread token.
    /// </summary>
    SetThreadToken = 0x0080,

    /// <summary>
    /// Impersonate the thread.
    /// </summary>
    Impersonate = 0x0100,

    /// <summary>
    /// Direct impersonation of the thread.
    /// </summary>
    DirectImpersonation = 0x0200
}
