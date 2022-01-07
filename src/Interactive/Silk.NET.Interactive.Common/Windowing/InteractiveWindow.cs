using Silk.NET.Core;
using Silk.NET.Core.Contexts;
using Silk.NET.Interactive.Common.Events;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.Windowing.Internals;

namespace Silk.NET.Interactive.Common.Windowing;

internal class InteractiveWindow : WindowImplementationBase, IWindowRenderer
{
    private readonly InteractiveWindowPlatform _owner;
    private readonly int _windowId;
    private bool _closing;
    private bool _mandatedClosure;
    private IGLContext? _glContext;
    private IVkSurface? _vkSurface = null;

    public InteractiveWindow(InteractiveWindowPlatform owner, int windowId, WindowOptions optionsCache)
        : base(optionsCache)
    {
        _owner = owner;
        _windowId = windowId;
    }

    protected override void CoreReset()
    {
        throw new NotImplementedException();
    }

    public override VideoMode VideoMode
        => throw new NotImplementedException("Video modes are not supported by Silk.NET Interactive today.");
    public override bool IsEventDriven { get; set; }
    public override Vector2D<int> FramebufferSize { get; }

    public override void DoEvents()
    {
        throw new NotImplementedException();
    }

    public override void ContinueEvents()
    {
        throw new NotImplementedException();
    }

    public override void Close() => _closing = true;

    protected override void RegisterCallbacks()
    {
        // do nothing
    }

    protected override void UnregisterCallbacks()
    {
        // do nothing
    }

    protected override INativeWindow GetNativeWindow()
    {
        throw new NotImplementedException();
    }

    public override event Action<Vector2D<int>>? Resize;
    public override event Action<Vector2D<int>>? FramebufferResize;
    public override event Action? Closing;
    public override event Action<bool>? FocusChanged;
    protected override bool CoreIsVisible { get; set; }
    protected override Vector2D<int> CorePosition { get; set; }
    protected override string CoreTitle { get; set; }
    protected override WindowState CoreWindowState { get; set; }
    protected override WindowBorder CoreWindowBorder { get; set; }

    protected override bool IsClosingSettable
    {
        set => throw new NotImplementedException();
    }

    protected override Vector2D<int> SizeSettable
    {
        set => throw new NotImplementedException();
    }

    protected override Rectangle<int> CoreBorderSize => new(0, 0, 0, 0);

    protected override void CoreInitialize(WindowOptions opts)
    {
        throw new NotImplementedException();
    }

    public override event Action<Vector2D<int>>? Move;
    public override event Action<WindowState>? StateChanged;
    public override event Action<string[]>? FileDrop;
    public override IWindow CreateWindow(WindowOptions opts) => _owner.CreateWindow(opts);

    public override IWindowHost? Parent => Monitor;

    public override IMonitor? Monitor
    {
        get => _owner;
        set
        {
            if (_owner != value) // setting the Monitor to the current monitor is a nop
            {
                throw new InvalidOperationException("Not a valid monitor.");
            }
        }
    }

    public override string? WindowClass => ExtendedOptionsCache.WindowClass;

    public override void SetWindowIcon(ReadOnlySpan<RawImage> icons)
        => throw new NotImplementedException("Window icons are not supported in Silk.NET Interactive today.");

    public void Notify(UserMovedWindow @event)
    {
        throw new NotImplementedException("");
    }

    public void Notify(NotifyUserWorkspaceBounds @event)
    {
        throw new NotImplementedException();
    }

    public void Notify(UserResizedWindow @event)
    {
        throw new NotImplementedException();
    }

    public void Notify(UserTappedWindow @event)
    {
        throw new NotImplementedException();
    }

    public void Notify(UserCloseRequested @event)
    {
        throw new NotImplementedException();
    }

    public void Notify(UserMinimizeRequested @event)
    {
        throw new NotImplementedException();
    }

    public void Notify(UserMaximizeRequested @event)
    {
        throw new NotImplementedException();
    }

    public void Notify(FramePresentedToUser @event)
    {
        throw new NotImplementedException();
    }

    // Boilerplate
    protected override Vector2D<int> CoreSize => ExtendedOptionsCache.Size;
    protected override nint CoreHandle => _windowId;
    protected override bool CoreIsClosing => _closing || _mandatedClosure;
    protected override IGLContext? CoreGLContext => _glContext;
    protected override IVkSurface? CoreVkSurface => _vkSurface;
    public override IGLContext? SharedContext { get; } = null;
}
