// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Numerics;

namespace Silk.NET.Interactive.Azure;

public record CmdGetEventsAck
(
    string[] Stdout,
    string[] Stderr,
    string Base64Frame,
    Vector2 Pos,
    Vector2 Size,
    bool IsCloseRequested
);
