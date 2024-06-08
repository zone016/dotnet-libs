// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Process;

/// <summary>
/// Provides a fluent API to configure and run external processes.
/// </summary>
public class Runner
{
    private readonly string _executable;
    private string _workingDirectory = Directory.GetCurrentDirectory();

    private readonly List<string> _arguments = [];

    private Action<string>? _outputDataReceivedCallback;
    private Action<string>? _errorDataReceivedCallback;

    private TimeSpan _timeout = TimeSpan.FromSeconds(60);
    private CancellationToken _cancellationToken = CancellationToken.None;

    /// <summary>
    /// Gets the full paths of the specified executable from the PATH environment variable.
    /// </summary>
    /// <param name="executable">The name of the executable to find.</param>
    /// <returns>
    /// An IEnumerable of strings, with full path of the executable found in the PATH environment variable.
    /// If the executable is not found in any directory specified in the PATH, the returned IEnumerable will be empty.
    /// If the executable is found in multiple directories, each path will be returned, with duplicates removed.
    /// </returns>
    public static IEnumerable<string> GetExecutablePathFromEnvironment(string executable) =>
        Environment.GetEnvironmentVariable("PATH")!.Split(Path.PathSeparator)
            .Select(path => Path.Combine(path, executable))
            .Where(File.Exists)
            .Distinct()
            .Select(Path.GetFullPath);

    /// <summary>
    /// Creates a new instance of the <see cref="Runner"/> class with the specified executable.
    /// </summary>
    /// <param name="executable">The name or path of the executable to run.</param>
    /// <returns>A new <see cref="Runner"/> instance configured to use the specified executable.</returns>
    /// <exception cref="FileNotFoundException">
    /// Thrown when the specified executable is not found in the file system or the PATH environment variable.
    /// </exception>
    /// <exception cref="AmbiguousExecutableNameMatchException">
    /// Thrown when multiple executables with the same name are found in the PATH environment variable.
    /// </exception>
    /// <remarks>
    /// The method first tries to resolve the full path of the executable.
    /// If it's not found, it looks for the executable in directories specified by the PATH environment variable.
    /// If still not found, or if multiple matches are found in the PATH, an exception is thrown.
    /// </remarks>
    public static Runner Create(string executable)
    {
        if (!File.Exists(executable))
        {
            var paths = GetExecutablePathFromEnvironment(executable).ToArray();
            switch (paths.Length)
            {
                case 0:
                    throw new FileNotFoundException();
                case > 1:
                    throw new AmbiguousExecutableNameMatchException(executable, paths);
            }

            executable = paths[0];
        }

        if (!File.Exists(executable))
        {
            throw new FileNotFoundException();
        }

        return new Runner(executable);
    }

    /// <summary>
    /// Sets the working directory for the process.
    /// </summary>
    /// <param name="workingDirectory">The working directory path.</param>
    /// <returns>The current <see cref="Runner"/> instance.</returns>
    /// <exception cref="DirectoryNotFoundException">Thrown when the specified directory does not exist.</exception>
    public Runner WithWorkingDirectory(string workingDirectory)
    {
        if (!Directory.Exists(workingDirectory))
        {
            throw new DirectoryNotFoundException();
        }

        _workingDirectory = workingDirectory;
        return this;
    }

    /// <summary>
    /// Sets the callback for processing standard output data.
    /// </summary>
    /// <param name="callback">The callback action.</param>
    /// <returns>The current <see cref="Runner"/> instance.</returns>
    public Runner WithOutputDataReceivedCallback(Action<string> callback)
    {
        _outputDataReceivedCallback = callback;
        return this;
    }

    /// <summary>
    /// Sets the callback for processing standard error data.
    /// </summary>
    /// <param name="callback">The callback action.</param>
    /// <returns>The current <see cref="Runner"/> instance.</returns>
    public Runner WithErrorDataReceivedCallback(Action<string> callback)
    {
        _errorDataReceivedCallback = callback;
        return this;
    }

    /// <summary>
    /// Sets the maximum time to wait for the process to complete.
    /// </summary>
    /// <param name="timeout">The timeout duration.</param>
    /// <returns>The current <see cref="Runner"/> instance.</returns>
    public Runner WithTimeout(TimeSpan timeout)
    {
        _timeout = timeout;
        return this;
    }

    /// <summary>
    /// Sets the cancellation token.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The current <see cref="Runner"/> instance.</returns>
    public Runner WithCancellationToken(CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;
        return this;
    }

    /// <summary>
    /// Adds arguments to pass to the process.
    /// </summary>
    /// <param name="arguments">The arguments to add.</param>
    /// <returns>The current <see cref="Runner"/> instance.</returns>
    public Runner WithArguments(params string[] arguments)
    {
        _arguments.AddRange(arguments);
        return this;
    }

    /// <summary>
    /// Asynchronously runs the configured external process.
    /// </summary>
    /// <returns>A <see cref="Task{Process}"/> representing the asynchronous operation.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the process cannot be started.
    /// </exception>
    /// <exception cref="TimeoutException">
    /// Thrown when the process does not start within the configured timeout.
    /// </exception>
    /// <remarks>
    /// This method configures and starts an external process based on the properties set
    /// in the <see cref="Runner"/> instance. It sets up callbacks for standard output and
    /// standard error if they have been configured. The method also respects the configured
    /// timeout and cancellation token for starting the process.
    /// 
    /// Note that the process is returned as soon as it is started successfully.
    /// </remarks>
    public async Task<System.Diagnostics.Process> RunAsync()
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = _executable,
            WorkingDirectory = _workingDirectory,
            RedirectStandardOutput = _outputDataReceivedCallback is not null,
            RedirectStandardError = _errorDataReceivedCallback is not null,
            UseShellExecute = false,
            CreateNoWindow = true,
            Arguments = string.Join(' ', _arguments)
        };

        var process = new System.Diagnostics.Process();
        process.StartInfo = processStartInfo;
        process.EnableRaisingEvents = true;

        if (_outputDataReceivedCallback is not null)
        {
            process.OutputDataReceived += (_, args) =>
            {
                var content = args.Data;
                if (string.IsNullOrEmpty(content))
                {
                    return;
                }

                _outputDataReceivedCallback(content);
            };
        }

        if (_errorDataReceivedCallback is not null)
        {
            process.ErrorDataReceived += (_, args) =>
            {
                var content = args.Data;
                if (string.IsNullOrEmpty(content))
                {
                    return;
                }

                _errorDataReceivedCallback(content);
            };
        }

        var cancellationSource = new CancellationTokenSource(_timeout);
        var linkedTokenSource =
            CancellationTokenSource.CreateLinkedTokenSource(_cancellationToken, cancellationSource.Token);

        try
        {
            var startTask = Task.Run(() =>
            {
                if (!process.Start())
                {
                    throw new InvalidOperationException();
                }

                if (_outputDataReceivedCallback is not null)
                {
                    process.BeginOutputReadLine();
                }

                if (_errorDataReceivedCallback is not null)
                {
                    process.BeginErrorReadLine();
                }
            }, linkedTokenSource.Token);

            // Wait for the process to start or timeout.
            await Task.WhenAny(startTask, Task.Delay(_timeout, linkedTokenSource.Token));

            if (startTask.IsFaulted)
            {
                // If there was an error starting the process, rethrow the exception.
                throw startTask.Exception!.GetBaseException();
            }

            if (!startTask.IsCompleted)
            {
                // If the process did not start within the timeout, kill it and throw a TimeoutException.
                if (!process.HasExited)
                {
                    process.Kill();
                }

                throw new TimeoutException();
            }

            // If the process started successfully, return it.
            return process;
        }
        catch (OperationCanceledException) when (cancellationSource.IsCancellationRequested)
        {
            // Handle the timeout case specifically.
            if (!process.HasExited)
            {
                process.Kill();
            }

            throw new TimeoutException();
        }
        catch
        {
            if (!process.HasExited)
            {
                process.Kill();
            }

            throw;
        }
    }

    /// <summary>
    /// Private constructor for specifying executable.
    /// </summary>
    /// <param name="executable">The path to the executable.</param>
    private Runner(string executable)
    {
        _executable = executable;
    }
}
