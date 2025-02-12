// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [Flags]
    [NativeName("Name", "VkAccelerationStructureCreateFlagsKHR")]
    public enum AccelerationStructureCreateFlagsKHR : int
    {
        [NativeName("Name", "")]
        None = 0,
        [Obsolete("Deprecated in favour of \"DeviceAddressCaptureReplayBitKhr\"")]
        [NativeName("Name", "VK_ACCELERATION_STRUCTURE_CREATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT_KHR")]
        AccelerationStructureCreateDeviceAddressCaptureReplayBitKhr = 1,
        [Obsolete("Deprecated in favour of \"Reserved3BitAmd\"")]
        [NativeName("Name", "VK_ACCELERATION_STRUCTURE_CREATE_RESERVED_3_BIT_AMD")]
        AccelerationStructureCreateReserved3BitAmd = 8,
        [Obsolete("Deprecated in favour of \"MotionBitNV\"")]
        [NativeName("Name", "VK_ACCELERATION_STRUCTURE_CREATE_MOTION_BIT_NV")]
        AccelerationStructureCreateMotionBitNV = 4,
        [NativeName("Name", "VK_ACCELERATION_STRUCTURE_CREATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT_KHR")]
        DeviceAddressCaptureReplayBitKhr = 1,
        [NativeName("Name", "VK_ACCELERATION_STRUCTURE_CREATE_RESERVED_3_BIT_AMD")]
        Reserved3BitAmd = 8,
        [NativeName("Name", "VK_ACCELERATION_STRUCTURE_CREATE_MOTION_BIT_NV")]
        MotionBitNV = 4,
    }
}
