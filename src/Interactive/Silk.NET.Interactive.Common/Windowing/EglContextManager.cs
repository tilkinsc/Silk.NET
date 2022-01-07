// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

namespace Silk.NET.Interactive.Common.Windowing;

internal class EglContextManager : IGLContext
{
    private readonly InteractiveWindow _owner;
    public EglContextManager(InteractiveWindow owner) => _owner = owner;
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public nint GetProcAddress(string proc, int? slot = default)
    {
        if (TryGetProcAddress(proc, out var addr))
        {
            return addr;
        }

        throw new SymbolLoadingException(proc);
    }

    public bool TryGetProcAddress(string proc, out nint addr, int? slot = default)
    {
        throw new NotImplementedException();
    }

    public nint Handle { get; private set; }
    public IGLContextSource? Source => _owner;
    public bool IsCurrent { get; }
    public void SwapInterval(int interval)
    {
        throw new NotImplementedException();
    }

    public void SwapBuffers()
    {
        throw new NotImplementedException();
    }

    public void MakeCurrent()
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }
}
