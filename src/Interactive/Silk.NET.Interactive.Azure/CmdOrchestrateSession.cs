using System;

namespace Silk.NET.Interactive.Azure;

public readonly record struct CmdOrchestrateSession
(
    Guid Id,
    CmdNewSession OriginalCommand
);