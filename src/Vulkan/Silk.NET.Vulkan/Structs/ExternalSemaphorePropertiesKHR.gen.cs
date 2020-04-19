// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Text;
using Silk.NET.Core.Native;
using Ultz.SuperInvoke;

namespace Silk.NET.Vulkan
{
    public unsafe struct ExternalSemaphorePropertiesKHR
    {
        public ExternalSemaphorePropertiesKHR
        (
            StructureType sType = StructureType.ExternalSemaphoreProperties,
            void* pNext = default,
            ExternalSemaphoreHandleTypeFlags exportFromImportedHandleTypes = default,
            ExternalSemaphoreHandleTypeFlags compatibleHandleTypes = default,
            ExternalSemaphoreFeatureFlags externalSemaphoreFeatures = default
        )
        {
           SType = sType;
           PNext = pNext;
           ExportFromImportedHandleTypes = exportFromImportedHandleTypes;
           CompatibleHandleTypes = compatibleHandleTypes;
           ExternalSemaphoreFeatures = externalSemaphoreFeatures;
        }

/// <summary></summary>
        public StructureType SType;
/// <summary></summary>
        public void* PNext;
/// <summary></summary>
        public ExternalSemaphoreHandleTypeFlags ExportFromImportedHandleTypes;
/// <summary></summary>
        public ExternalSemaphoreHandleTypeFlags CompatibleHandleTypes;
/// <summary></summary>
        public ExternalSemaphoreFeatureFlags ExternalSemaphoreFeatures;
    }
}