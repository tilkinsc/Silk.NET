// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.WebGPU
{
    [Flags]
    [NativeName("Name", "WGPUStorageTextureAccess")]
    public enum StorageTextureAccess : int
    {
        [NativeName("Name", "")]
        None = 0,
        [NativeName("Name", "WGPUStorageTextureAccess_Undefined")]
        Undefined = 0x0,
        [NativeName("Name", "WGPUStorageTextureAccess_WriteOnly")]
        WriteOnly = 0x1,
        [NativeName("Name", "WGPUStorageTextureAccess_Force32")]
        Force32 = 0x7FFFFFFF,
    }
}
