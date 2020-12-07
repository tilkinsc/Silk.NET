// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.Extensions.KHR
{
    public static class KhrGetPhysicalDeviceProperties2Overloads
    {
        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceFeatures2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.Out)] Span<PhysicalDeviceFeatures2> pFeatures)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceFeatures2(physicalDevice, out pFeatures.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0)] Format format, [Count(Count = 0), Flow(FlowDirection.Out)] Span<FormatProperties2> pFormatProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceFormatProperties2(physicalDevice, format, out pFormatProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe Result GetPhysicalDeviceImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] PhysicalDeviceImageFormatInfo2* pImageFormatInfo, [Count(Count = 0), Flow(FlowDirection.Out)] Span<ImageFormatProperties2> pImageFormatProperties)
        {
            // SpanOverloader
            return thisApi.GetPhysicalDeviceImageFormatProperties2(physicalDevice, pImageFormatInfo, out pImageFormatProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe Result GetPhysicalDeviceImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] ReadOnlySpan<PhysicalDeviceImageFormatInfo2> pImageFormatInfo, [Count(Count = 0), Flow(FlowDirection.Out)] ImageFormatProperties2* pImageFormatProperties)
        {
            // SpanOverloader
            return thisApi.GetPhysicalDeviceImageFormatProperties2(physicalDevice, in pImageFormatInfo.GetPinnableReference(), pImageFormatProperties);
        }

        /// <summary>To be added.</summary>
        public static unsafe Result GetPhysicalDeviceImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] ReadOnlySpan<PhysicalDeviceImageFormatInfo2> pImageFormatInfo, [Count(Count = 0), Flow(FlowDirection.Out)] Span<ImageFormatProperties2> pImageFormatProperties)
        {
            // SpanOverloader
            return thisApi.GetPhysicalDeviceImageFormatProperties2(physicalDevice, in pImageFormatInfo.GetPinnableReference(), out pImageFormatProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceMemoryProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.Out)] Span<PhysicalDeviceMemoryProperties2> pMemoryProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceMemoryProperties2(physicalDevice, out pMemoryProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.Out)] Span<PhysicalDeviceProperties2> pProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceProperties2(physicalDevice, out pProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceQueueFamilyProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0)] uint* pQueueFamilyPropertyCount, [Count(Computed = "pQueueFamilyPropertyCount"), Flow(FlowDirection.Out)] Span<QueueFamilyProperties2> pQueueFamilyProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceQueueFamilyProperties2(physicalDevice, pQueueFamilyPropertyCount, out pQueueFamilyProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceQueueFamilyProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0)] Span<uint> pQueueFamilyPropertyCount, [Count(Computed = "pQueueFamilyPropertyCount"), Flow(FlowDirection.Out)] QueueFamilyProperties2* pQueueFamilyProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceQueueFamilyProperties2(physicalDevice, ref pQueueFamilyPropertyCount.GetPinnableReference(), pQueueFamilyProperties);
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceQueueFamilyProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0)] Span<uint> pQueueFamilyPropertyCount, [Count(Computed = "pQueueFamilyPropertyCount"), Flow(FlowDirection.Out)] Span<QueueFamilyProperties2> pQueueFamilyProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceQueueFamilyProperties2(physicalDevice, ref pQueueFamilyPropertyCount.GetPinnableReference(), out pQueueFamilyProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceSparseImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] PhysicalDeviceSparseImageFormatInfo2* pFormatInfo, [Count(Count = 0)] uint* pPropertyCount, [Count(Computed = "pPropertyCount"), Flow(FlowDirection.Out)] Span<SparseImageFormatProperties2> pProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceSparseImageFormatProperties2(physicalDevice, pFormatInfo, pPropertyCount, out pProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceSparseImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] PhysicalDeviceSparseImageFormatInfo2* pFormatInfo, [Count(Count = 0)] Span<uint> pPropertyCount, [Count(Computed = "pPropertyCount"), Flow(FlowDirection.Out)] SparseImageFormatProperties2* pProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceSparseImageFormatProperties2(physicalDevice, pFormatInfo, ref pPropertyCount.GetPinnableReference(), pProperties);
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceSparseImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] PhysicalDeviceSparseImageFormatInfo2* pFormatInfo, [Count(Count = 0)] Span<uint> pPropertyCount, [Count(Computed = "pPropertyCount"), Flow(FlowDirection.Out)] Span<SparseImageFormatProperties2> pProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceSparseImageFormatProperties2(physicalDevice, pFormatInfo, ref pPropertyCount.GetPinnableReference(), out pProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceSparseImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] ReadOnlySpan<PhysicalDeviceSparseImageFormatInfo2> pFormatInfo, [Count(Count = 0)] uint* pPropertyCount, [Count(Computed = "pPropertyCount"), Flow(FlowDirection.Out)] SparseImageFormatProperties2* pProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceSparseImageFormatProperties2(physicalDevice, in pFormatInfo.GetPinnableReference(), pPropertyCount, pProperties);
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceSparseImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] ReadOnlySpan<PhysicalDeviceSparseImageFormatInfo2> pFormatInfo, [Count(Count = 0)] uint* pPropertyCount, [Count(Computed = "pPropertyCount"), Flow(FlowDirection.Out)] Span<SparseImageFormatProperties2> pProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceSparseImageFormatProperties2(physicalDevice, in pFormatInfo.GetPinnableReference(), pPropertyCount, out pProperties.GetPinnableReference());
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceSparseImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] ReadOnlySpan<PhysicalDeviceSparseImageFormatInfo2> pFormatInfo, [Count(Count = 0)] Span<uint> pPropertyCount, [Count(Computed = "pPropertyCount"), Flow(FlowDirection.Out)] SparseImageFormatProperties2* pProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceSparseImageFormatProperties2(physicalDevice, in pFormatInfo.GetPinnableReference(), ref pPropertyCount.GetPinnableReference(), pProperties);
        }

        /// <summary>To be added.</summary>
        public static unsafe void GetPhysicalDeviceSparseImageFormatProperties2(this KhrGetPhysicalDeviceProperties2 thisApi, [Count(Count = 0)] PhysicalDevice physicalDevice, [Count(Count = 0), Flow(FlowDirection.In)] ReadOnlySpan<PhysicalDeviceSparseImageFormatInfo2> pFormatInfo, [Count(Count = 0)] Span<uint> pPropertyCount, [Count(Computed = "pPropertyCount"), Flow(FlowDirection.Out)] Span<SparseImageFormatProperties2> pProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceSparseImageFormatProperties2(physicalDevice, in pFormatInfo.GetPinnableReference(), ref pPropertyCount.GetPinnableReference(), out pProperties.GetPinnableReference());
        }

    }
}
