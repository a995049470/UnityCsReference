// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using UnityEditor.PackageManager.UI.Internal;

namespace UnityEditor.Connect
{
    static class ServicesConstants
    {
        public const int ExploreServicesTopMenuPriority = int.MinValue;
        public const int GeneralSettingsServicesTopMenuPriority = int.MinValue + 1;

        public static readonly string ExploreServicesPackageManagerPageId = ExtensionPage.GetIdFromName(EditorGameServiceExtension.k_ServicesExtensionPageName);
    }
}
