// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Bindings;
using uei = UnityEngine.Internal;

namespace UnityEditor.SceneManagement
{
    // Bit mask that controls the enabled features on a preview scene
    [System.Flags]
    internal enum PreviewSceneFlags
    {
        NoFlags = 0,
        IsPreviewScene = 1,
        AllowCamerasForRendering = 2,
        AllowMonoBehaviourEvents = 4,
        AllowGlobalIlluminationLights = 8,
        AllowAutoPlayAudioSources = 16,
        AllFlags = 1 + 2 + 4 + 8 + 16
    }

    [NativeHeader("Runtime/SceneManager/SceneManager.h")]
    [NativeHeader("Modules/AssetPipelineEditor/Public/DefaultImporter.h")]
    [NativeHeader("Editor/Mono/EditorSceneManager.bindings.h")]
    public sealed partial class EditorSceneManager : SceneManager
    {
        [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
        [NativeMethod("IsReloading")]
        public extern static bool IsReloading(Scene scene);

        public extern static int loadedRootSceneCount
        {
            [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
            [NativeMethod("GetLoadedRootSceneCount")]
            get;
        }

        public extern static int previewSceneCount
        {
            [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
            [NativeMethod("GetPreviewSceneCount")]
            get;
        }

        public extern static bool preventCrossSceneReferences
        {
            [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
            [NativeMethod("IsPreventingCrossSceneReferences")]
            get;

            [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
            [NativeMethod("SetPreventCrossSceneReferences")]
            set;
        }

        public extern static SceneAsset playModeStartScene
        {
            [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
            [NativeMethod("GetPlayModeStartScene")]
            get;

            [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
            [NativeMethod("SetPlayModeStartScene")]
            set;
        }

        [FreeFunction("GetSceneTracker().CanOpenScene")]
        internal static extern bool CanOpenScene();

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("OpenScene")]
        public extern static Scene OpenScene(string scenePath, [uei.DefaultValue("OpenSceneMode.Single")] OpenSceneMode mode);

        public static Scene OpenPreviewScene(string scenePath)
        {
            return OpenPreviewScene(scenePath, true);
        }

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("OpenPreviewScene")]
        internal extern static Scene OpenPreviewScene(string scenePath, bool allocateSceneCullingMask);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("NewScene")]
        public extern static Scene NewScene(NewSceneSetup setup, [uei.DefaultValue("NewSceneMode.Single")] NewSceneMode mode);

        public static Scene NewPreviewScene()
        {
            return NewPreviewScene(true, PreviewSceneFlags.IsPreviewScene);
        }

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("NewPreviewScene")]
        internal extern static Scene NewPreviewScene(bool allocateSceneCullingMask, PreviewSceneFlags previewSceneFlags = PreviewSceneFlags.IsPreviewScene);

        [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
        [NativeMethod("CreateSceneAsset")]
        private extern static bool CreateSceneAssetInternal(string scenePath, bool createDefaultGameObjects);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("RemapAssetReferencesInSceneInternal")]
        private extern static void RemapAssetReferencesInSceneInternal(UnityEngine.SceneManagement.Scene scene, string[] srcPaths, string[] dstPaths, int[] srcIds, int[] dstIds);

        internal static void RemapAssetReferencesInScene(UnityEngine.SceneManagement.Scene scene, Dictionary<string, string> pathMap, Dictionary<int, int> idMap = null)
        {
            RemapAssetReferencesInSceneInternal(scene,
                pathMap.Keys.ToArray(), pathMap.Values.ToArray(),
                idMap == null ? new int[0] : idMap.Keys.ToArray(),
                idMap == null ? new int[0] : idMap.Values.ToArray()
            );
        }

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("CloseScene")]
        public extern static bool CloseScene(Scene scene, bool removeScene);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("ClosePreviewScene")]
        public extern static bool ClosePreviewScene(Scene scene);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("IsPreviewScene")]
        public extern static bool IsPreviewScene(Scene scene);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("SetPreviewScenesVisibleInHierarchy")]
        internal extern static void SetPreviewScenesVisibleInHierarchy(bool visible);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("GetPreviewScenesVisibleInHierarchy")]
        internal extern static bool GetPreviewScenesVisibleInHierarchy();

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("IsPreviewSceneObject")]
        public extern static bool IsPreviewSceneObject(UnityEngine.Object obj);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("IsAuthoringScene")]
        internal extern static bool IsAuthoringScene(Scene scene);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("ReloadScene")]
        internal extern static bool ReloadScene(Scene scene);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("ClearOpenScenesChangedOnDisk")]
        internal extern static void ClearOpenScenesChangedOnDisk();

        internal static void SetTargetSceneForNewGameObjects(Scene scene) { SetTargetSceneForNewGameObjects(scene.handle); }

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("ClearTargetSceneForNewGameObjects")]
        internal extern static void ClearTargetSceneForNewGameObjects();

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("SetTargetSceneForNewGameObjects")]
        internal extern static void SetTargetSceneForNewGameObjects(int sceneHandle);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("GetTargetSceneForNewGameObjects")]
        internal extern static Scene GetTargetSceneForNewGameObjects();

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("GetSceneByHandle")]
        internal extern static Scene GetSceneByHandle(int handle);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("MoveSceneBefore")]
        public extern static void MoveSceneBefore(Scene src, Scene dst);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("MoveSceneAfter")]
        public extern static void MoveSceneAfter(Scene src, Scene dst);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("SaveSceneAs")]
        internal extern static bool SaveSceneAs(Scene scene);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("SaveSceneInternal")]
        private extern static bool SaveSceneInternal(Scene scene, string dstScenePath, bool saveAsCopy);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("SaveOpenScenes")]
        public extern static bool SaveOpenScenes();

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("SaveScenes")]
        public extern static bool SaveScenes([NotNull] Scene[] scenes);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("SaveCurrentModifiedScenesIfUserWantsTo")]
        internal extern static bool SaveCurrentModifiedScenesIfUserWantsTo(string message);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("SaveModifiedScenesIfUserWantsTo")]
        public extern static bool SaveModifiedScenesIfUserWantsTo([NotNull] Scene[] scenes);

        [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
        [NativeMethod("EnsureUntitledSceneHasBeenSaved")]
        public extern static bool EnsureUntitledSceneHasBeenSaved(string dialogContent);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("MarkSceneDirty")]
        public extern static bool MarkSceneDirty(Scene scene);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("MarkAllScenesDirty")]
        public extern static void MarkAllScenesDirty();

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("ClearSceneDirtiness")]
        internal extern static void ClearSceneDirtiness(Scene scene);

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("GetSceneManagerSetup")]
        public extern static SceneSetup[] GetSceneManagerSetup();

        [NativeThrows]
        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("RestoreSceneManagerSetup")]
        public extern static void RestoreSceneManagerSetup(SceneSetup[] value);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("LoadSceneManagerSetup")]
        internal extern static bool LoadSceneManagerSetup(string path);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        internal static extern bool LoadLastSceneManagerSetup();

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        [NativeMethod("DetectCrossSceneReferences")]
        public extern static bool DetectCrossSceneReferences(Scene scene);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        private extern static AsyncOperation LoadSceneInPlayModeInternal(string path, LoadSceneParameters parameters, bool isSynchronous);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        extern public static ulong GetSceneCullingMask(Scene scene);

        [StaticAccessor("EditorSceneManagerBindings", StaticAccessorType.DoubleColon)]
        extern public static void SetSceneCullingMask(Scene scene, ulong sceneCullingMask);

        [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
        extern public static ulong CalculateAvailableSceneCullingMask();

        // Use SceneCullingMasks.DefaultSceneCullingMask
        public const ulong DefaultSceneCullingMask = SceneCullingMasks.DefaultSceneCullingMask;
    }

    public static class SceneCullingMasks
    {
        // If updating the bits here ensure kDefaultSceneCullingMask (in C++) is in sync. Also ensure EditorSceneManager.DefaultSceneCullingMask is in sync.
        public const ulong DefaultSceneCullingMask = GameViewObjects | MainStageSceneViewObjects;
        public const ulong GameViewObjects = 1UL << 63;
        public const ulong MainStageSceneViewObjects = MainStagePrefabInstanceObjectsOpenInPrefabMode | MainStageExcludingPrefabInstanceObjectsOpenInPrefabMode;

        internal const ulong MainStageExcludingPrefabInstanceObjectsOpenInPrefabMode = 1UL << 62;
        internal const ulong MainStagePrefabInstanceObjectsOpenInPrefabMode = 1UL << 61;
        internal const ulong PrefabStagePrefabInstanceObjectsOpenInPrefabMode = 1UL << 60;
    }
}
