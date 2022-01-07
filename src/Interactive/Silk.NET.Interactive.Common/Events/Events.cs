// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Numerics;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Silk.NET.Interactive.Common.Events;

// Sent from JavaScript -> C#
public readonly record struct UserMovedWindow(Vector2 NewPosition);
public readonly record struct NotifyUserWorkspaceBounds(Vector2 Size);
public readonly record struct UserResizedWindow(Vector2 NewSize);
public readonly record struct UserTappedWindow(int NumTaps);
public readonly record struct UserCloseRequested;
public readonly record struct UserMinimizeRequested;
public readonly record struct UserMaximizeRequested;
public readonly record struct FramePresentedToUser; // "vsync"
// TODO Support for keyboard and gamepads

public interface IWindowRenderer : IActor<UserMovedWindow>,
    IActor<NotifyUserWorkspaceBounds>,
    IActor<UserResizedWindow>,
    IActor<UserTappedWindow>,
    IActor<UserCloseRequested>,
    IActor<UserMinimizeRequested>,
    IActor<UserMaximizeRequested>,
    IActor<FramePresentedToUser>
{
}

// Sent from C# -> JavaScript
public readonly record struct WindowCreated(int WindowId);
public readonly record struct WindowIsVisibleChanged(int WindowId, bool Value);
public readonly record struct WindowPositionChanged(int WindowId, Vector2D<int> Value);
public readonly record struct WindowSizeChanged(int WindowId, Vector2D<int> Value);
public readonly record struct WindowTitleChanged(int WindowId, string Value);
public readonly record struct WindowWindowStateChanged(int WindowId, WindowState Value);
public readonly record struct WindowWindowBorderChanged(int WindowId, WindowBorder Value);
public readonly record struct WindowIsClosingChanged(int WindowId, bool Value);
public readonly record struct WindowPushFrame(int WindowId, string Base64Png);
public readonly record struct WindowDestroyed(int WindowId);

public interface IWindowPresenter : IActor<WindowCreated>,
    IActor<WindowIsVisibleChanged>,
    IActor<WindowPositionChanged>,
    IActor<WindowSizeChanged>,
    IActor<WindowTitleChanged>,
    IActor<WindowWindowStateChanged>,
    IActor<WindowWindowBorderChanged>,
    IActor<WindowIsClosingChanged>,
    IActor<WindowPushFrame>,
    IActor<WindowDestroyed>
{
}