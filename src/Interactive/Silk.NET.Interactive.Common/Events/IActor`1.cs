// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Silk.NET.Interactive.Common;

public interface IActor<in T> where T:struct
{
    void Notify(T @event);
}
