// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using System;

namespace UnityEngine
{
    [NativeHeader("Modules/ImageConversion/ScriptBindings/ImageConversion.bindings.h")]
    public static class ImageConversion
    {
        public static bool EnableLegacyPngGammaRuntimeLoadBehavior
        {
            get
            {
                return GetEnableLegacyPngGammaRuntimeLoadBehavior();
            }
            set
            {
                SetEnableLegacyPngGammaRuntimeLoadBehavior(value);
            }
        }

        [NativeMethod(Name = "ImageConversionBindings::GetEnableLegacyPngGammaRuntimeLoadBehavior", IsFreeFunction = true, ThrowsException = false)]
        extern private static bool GetEnableLegacyPngGammaRuntimeLoadBehavior();

        [NativeMethod(Name = "ImageConversionBindings::SetEnableLegacyPngGammaRuntimeLoadBehavior", IsFreeFunction = true, ThrowsException = false)]
        extern private static void SetEnableLegacyPngGammaRuntimeLoadBehavior(bool enable);

        [NativeMethod(Name = "ImageConversionBindings::EncodeToTGA", IsFreeFunction = true, ThrowsException = true)]
        extern public static byte[] EncodeToTGA(this Texture2D tex);

        [NativeMethod(Name = "ImageConversionBindings::EncodeToPNG", IsFreeFunction = true, ThrowsException = true)]
        extern public static byte[] EncodeToPNG(this Texture2D tex);

        [NativeMethod(Name = "ImageConversionBindings::EncodeToJPG", IsFreeFunction = true, ThrowsException = true)]
        extern public static byte[] EncodeToJPG(this Texture2D tex, int quality);
        public static byte[] EncodeToJPG(this Texture2D tex)
        {
            return tex.EncodeToJPG(75);
        }

        [NativeMethod(Name = "ImageConversionBindings::EncodeToEXR", IsFreeFunction = true, ThrowsException = true)]
        extern public static byte[] EncodeToEXR(this Texture2D tex, Texture2D.EXRFlags flags);
        public static byte[] EncodeToEXR(this Texture2D tex)
        {
            return EncodeToEXR(tex, Texture2D.EXRFlags.None);
        }

        [NativeMethod(Name = "ImageConversionBindings::LoadImage", IsFreeFunction = true)]
        extern public static bool LoadImage([NotNull] this Texture2D tex, byte[] data, bool markNonReadable);
        public static bool LoadImage(this Texture2D tex, byte[] data)
        {
            return LoadImage(tex, data, false);
        }

        [FreeFunctionAttribute("ImageConversionBindings::EncodeArrayToTGA", true)]
        extern private static byte[] EncodeArrayToTGA_Internal(Span<byte> span, GraphicsFormat format, uint width, uint height, uint rowBytes);

        public static byte[] EncodeArrayToTGA(System.Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0)
        {
            var elemSize = array != null ? UnsafeUtility.SizeOf(array.GetType().GetElementType()) : 1;
            return EncodeArrayToTGA_Internal(UnsafeUtility.GetByteSpanFromArray(array, elemSize), format, width, height, rowBytes);
        }

        [FreeFunctionAttribute("ImageConversionBindings::EncodeArrayToPNG", true)]
        extern private static byte[] EncodeArrayToPNG_Internal(Span<byte> span, GraphicsFormat format, uint width, uint height, uint rowBytes);

        public static byte[] EncodeArrayToPNG(System.Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0)
        {
            var elemSize = array != null ? UnsafeUtility.SizeOf(array.GetType().GetElementType()) : 1;
            return EncodeArrayToPNG_Internal(UnsafeUtility.GetByteSpanFromArray(array, elemSize), format, width, height, rowBytes);
        }

        [FreeFunctionAttribute("ImageConversionBindings::EncodeArrayToJPG", true)]
        extern private static byte[] EncodeArrayToJPG_Internal(Span<byte> span, GraphicsFormat format, uint width, uint height, uint rowBytes, int quality);

        public static byte[] EncodeArrayToJPG(System.Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0, int quality = 75)
        {
            var elemSize = array != null ? UnsafeUtility.SizeOf(array.GetType().GetElementType()) : 1;
            return EncodeArrayToJPG_Internal(UnsafeUtility.GetByteSpanFromArray(array, elemSize), format, width, height, rowBytes, quality);
        }

        [FreeFunctionAttribute("ImageConversionBindings::EncodeArrayToEXR", true)]
        extern private static byte[] EncodeArrayToEXR_Internal(Span<byte> span, GraphicsFormat format, uint width, uint height, uint rowBytes, Texture2D.EXRFlags flags);

        public static byte[] EncodeArrayToEXR(System.Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None)
        {
            var elemSize = array != null ? UnsafeUtility.SizeOf(array.GetType().GetElementType()) : 1;
            return EncodeArrayToEXR_Internal(UnsafeUtility.GetByteSpanFromArray(array, elemSize), format, width, height, rowBytes, flags);
        }

        public static NativeArray<byte> EncodeNativeArrayToTGA<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0) where T : struct
        {
            unsafe
            {
                var size   = input.Length * UnsafeUtility.SizeOf<T>();
                var result = UnsafeEncodeNativeArrayToTGA(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(input), ref size, format, width, height, rowBytes);
                var output = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(result, size, Allocator.Persistent);
                var safety = AtomicSafetyHandle.Create();
                NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref output, safety);
                AtomicSafetyHandle.SetAllowReadOrWriteAccess(safety, true);
                return output;
            }
        }

        public static NativeArray<byte> EncodeNativeArrayToPNG<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0) where T : struct
        {
            unsafe
            {
                var size   = input.Length * UnsafeUtility.SizeOf<T>();
                var result = UnsafeEncodeNativeArrayToPNG(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(input), ref size, format, width, height, rowBytes);
                var output = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(result, size, Allocator.Persistent);
                var safety = AtomicSafetyHandle.Create();
                NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref output, safety);
                AtomicSafetyHandle.SetAllowReadOrWriteAccess(safety, true);
                return output;
            }
        }

        public static NativeArray<byte> EncodeNativeArrayToJPG<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0, int quality = 75) where T : struct
        {
            unsafe
            {
                var size   = input.Length * UnsafeUtility.SizeOf<T>();
                var result = UnsafeEncodeNativeArrayToJPG(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(input), ref size, format, width, height, rowBytes, quality);
                var output = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(result, size, Allocator.Persistent);
                var safety = AtomicSafetyHandle.Create();
                NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref output, safety);
                AtomicSafetyHandle.SetAllowReadOrWriteAccess(safety, true);
                return output;
            }
        }

        public static NativeArray<byte> EncodeNativeArrayToEXR<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None) where T : struct
        {
            unsafe
            {
                var size   = input.Length * UnsafeUtility.SizeOf<T>();
                var result = UnsafeEncodeNativeArrayToEXR(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(input), ref size, format, width, height, rowBytes, flags);
                var output = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(result, size, Allocator.Persistent);
                var safety = AtomicSafetyHandle.Create();
                NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref output, safety);
                AtomicSafetyHandle.SetAllowReadOrWriteAccess(safety, true);
                return output;
            }
        }

        [FreeFunctionAttribute("ImageConversionBindings::UnsafeEncodeNativeArrayToTGA", true)]
        unsafe extern static void* UnsafeEncodeNativeArrayToTGA(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0);

        [FreeFunctionAttribute("ImageConversionBindings::UnsafeEncodeNativeArrayToPNG", true)]
        unsafe extern static void* UnsafeEncodeNativeArrayToPNG(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0);

        [FreeFunctionAttribute("ImageConversionBindings::UnsafeEncodeNativeArrayToJPG", true)]
        unsafe extern static void* UnsafeEncodeNativeArrayToJPG(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0, int quality = 75);

        [FreeFunctionAttribute("ImageConversionBindings::UnsafeEncodeNativeArrayToEXR", true)]
        unsafe extern static void* UnsafeEncodeNativeArrayToEXR(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None);

        [FreeFunctionAttribute("ImageConversionBindings::LoadImageAtPathInternal", true)]
        unsafe extern static void* LoadImageAtPathInternal(string path, ref int width, ref int height, ref int rowBytes, ref GraphicsFormat format);
        unsafe internal static NativeArray<byte> LoadImageDataAtPath(string path, ref int width, ref int height, ref int rowBytes, ref GraphicsFormat format)
        {
            var buffer = LoadImageAtPathInternal(path, ref width, ref height, ref rowBytes, ref format);
            var size = height * rowBytes;
            var output = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(buffer, size, Allocator.Persistent);
            var safety = AtomicSafetyHandle.Create();
            NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref output, safety);
            AtomicSafetyHandle.SetAllowReadOrWriteAccess(safety, true);
            return output;
        }

    }
}
