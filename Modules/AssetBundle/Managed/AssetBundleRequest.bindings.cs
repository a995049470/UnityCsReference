// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine
{
    // Asynchronous load request from an [[AssetBundle]].
    [StructLayout(LayoutKind.Sequential)]
    [RequiredByNativeCode]
    [NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
    public class AssetBundleRequest : ResourceRequest
    {
        [NativeMethod("GetLoadedAsset")]
        protected override extern Object GetResult();

        public new Object asset { get { return GetResult(); } }

        public extern Object[] allAssets
        {
            [NativeMethod("GetAllLoadedAssets")]
            get;
        }
    }
}
