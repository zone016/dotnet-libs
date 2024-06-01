// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus.Tests;

[TestClass]
public class IntegrationTestOfOctopus
{
    [TestMethod]
    public void TestThreadCreation()
    {
        var octopus = Octopus.Instance;
        var registration = octopus.Register(Modifiers.Alt, VirtualKeyCode.KeyZ);

        Assert.IsNotNull(registration);
        Assert.IsTrue(registration.IsSuccessful);

        var identifiers = Process.GetCurrentProcess()
            .Threads
            .Cast<ProcessThread>()
            .Select(thread => thread.Id)
            .Select(threadId =>
                Kernel32.OpenThread(ThreadAccess.QueryInformation | ThreadAccess.SuspendResume,
                    false,
                    checked((uint)threadId)))
            .Where(handle => handle != IntPtr.Zero)
            .Select(Kernel32.GetThreadId)
            .ToArray();

        Assert.IsNotNull(identifiers);
        Assert.IsTrue(identifiers.Length > 0);

        var found = false;
        foreach (var identifier in identifiers)
        {
            var handle = Kernel32.OpenThread(ThreadAccess.QueryInformation, false, identifier);
            if (handle == IntPtr.Zero)
            {
                continue;
            }

            try
            {
                Kernel32.GetThreadDescription(handle, out var pointer);
                if (pointer == IntPtr.Zero)
                {
                    continue;
                }

                var literal = Marshal.PtrToStringUni(pointer);
                if (string.IsNullOrEmpty(literal))
                {
                    continue;
                }

                const string Fragment = "Octopus";
                if (literal.Contains(Fragment))
                {
                    found = true;
                    break;
                }
            }
            finally
            {
                Kernel32.CloseHandle(handle);
            }
        }

        octopus.Dispose();
        registration.Dispose();

        Assert.IsTrue(found);
    }
}
