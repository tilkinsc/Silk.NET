// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Direct3D9
{
    [Flags]
    [NativeName("Name", "_D3DCUBEMAP_FACES")]
    public enum CubemapFaces : int
    {
        [NativeName("Name", "")]
        None = 0,
        [Obsolete("Deprecated in favour of \"PositiveX\"")]
        [NativeName("Name", "D3DCUBEMAP_FACE_POSITIVE_X")]
        CubemapFacePositiveX = 0x0,
        [Obsolete("Deprecated in favour of \"NegativeX\"")]
        [NativeName("Name", "D3DCUBEMAP_FACE_NEGATIVE_X")]
        CubemapFaceNegativeX = 0x1,
        [Obsolete("Deprecated in favour of \"PositiveY\"")]
        [NativeName("Name", "D3DCUBEMAP_FACE_POSITIVE_Y")]
        CubemapFacePositiveY = 0x2,
        [Obsolete("Deprecated in favour of \"NegativeY\"")]
        [NativeName("Name", "D3DCUBEMAP_FACE_NEGATIVE_Y")]
        CubemapFaceNegativeY = 0x3,
        [Obsolete("Deprecated in favour of \"PositiveZ\"")]
        [NativeName("Name", "D3DCUBEMAP_FACE_POSITIVE_Z")]
        CubemapFacePositiveZ = 0x4,
        [Obsolete("Deprecated in favour of \"NegativeZ\"")]
        [NativeName("Name", "D3DCUBEMAP_FACE_NEGATIVE_Z")]
        CubemapFaceNegativeZ = 0x5,
        [Obsolete("Deprecated in favour of \"ForceDword\"")]
        [NativeName("Name", "D3DCUBEMAP_FACE_FORCE_DWORD")]
        CubemapFaceForceDword = 0x7FFFFFFF,
        [NativeName("Name", "D3DCUBEMAP_FACE_POSITIVE_X")]
        PositiveX = 0x0,
        [NativeName("Name", "D3DCUBEMAP_FACE_NEGATIVE_X")]
        NegativeX = 0x1,
        [NativeName("Name", "D3DCUBEMAP_FACE_POSITIVE_Y")]
        PositiveY = 0x2,
        [NativeName("Name", "D3DCUBEMAP_FACE_NEGATIVE_Y")]
        NegativeY = 0x3,
        [NativeName("Name", "D3DCUBEMAP_FACE_POSITIVE_Z")]
        PositiveZ = 0x4,
        [NativeName("Name", "D3DCUBEMAP_FACE_NEGATIVE_Z")]
        NegativeZ = 0x5,
        [NativeName("Name", "D3DCUBEMAP_FACE_FORCE_DWORD")]
        ForceDword = 0x7FFFFFFF,
    }
}
