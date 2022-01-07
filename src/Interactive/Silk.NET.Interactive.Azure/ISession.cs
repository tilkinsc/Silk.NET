// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Threading.Tasks;

namespace Silk.NET.Interactive.Azure;

public interface ISession
{
    Task RunAsync(CmdOrchestrateSession command);
}
