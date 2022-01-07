// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Silk.NET.Interactive.Common.Windowing;

public class InteractiveWindowPlatform : IWindowPlatform, IMonitor
{
    private Dictionary<int, InteractiveWindow> _windows = new();
    private int _nextWindowId = 1;
    public IWindow CreateWindow(WindowOptions opts)
    {
        throw new NotImplementedException();
    }

    public bool IsViewOnly { get; }
    public bool IsApplicable { get; }

    /// <inheritdoc />
    public IView GetView(ViewOptions? opts = null) => opts switch
    {
        null when !_windows.Any() => throw new InvalidOperationException
        (
            "No view has been created prior to this call, and couldn't " +
            "create one due to no view options being provided."
        ),
        // i know this is expensive but i just don't care:
        null => _windows.OrderByDescending(x => x.Key).First().Value,
        _ => CreateWindow(new WindowOptions(opts.Value))
    };

    public void ClearContexts()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IMonitor> GetMonitors()
    {
        yield return this;
    }
    public IMonitor GetMainMonitor() => this;
    public bool IsSourceOfView(IView view) => view is InteractiveWindow && _windows.ContainsKey((int) view.Handle);
    public string Name { get; } = "Silk.NET Interactive Virtual Monitor";
    public int Index { get; } = 0;
    public Rectangle<int> Bounds { get; private set; }

    public VideoMode VideoMode
        => throw new NotImplementedException("Video modes are not supported by Silk.NET Interactive today.");

    public float Gamma
    {
        get => throw new NotImplementedException("Video modes are not supported by Silk.NET Interactive today.");
        set => throw new NotImplementedException("Video modes are not supported by Silk.NET Interactive today.");
    }

    public IEnumerable<VideoMode> GetAllVideoModes()
    {
        throw new NotImplementedException("Video modes are not supported by Silk.NET Interactive today.");
    }
}
