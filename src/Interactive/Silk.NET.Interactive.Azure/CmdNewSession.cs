// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Silk.NET.Interactive.Azure;

public readonly record struct CmdNewSession
(
    Language Language,
    string[] Code
);