using static UnityEditor.AssetDatabase;
using UnityEditor;

public static class ToolMenu
{
    [MenuItem("Tools/Setup/Create Default Folders")]
    public static void CreateDefaultFolders()
    {
        Folders.CreateDirectories("_Project",
            "Animations",
            "Materials",
            "Models",
            "Prefabs",
            "Scenes",
            "Scripts",
            "Shaders",
            "Textures");
        Refresh();
    }

    [MenuItem("Tools/Setup/Reset Packages To Default")]
    public static void ResetPackagesToDefault() => PackageInstaller.ResetPackagesToDefault();
    
    [MenuItem("Tools/Setup/Load Standard Manifest")]
    public static async void LoadStandardManifest() => 
        await PackageInstaller.ReplaceManifestFromGist("c67f9d842fa7ecbf4d71f4ba044adfb7");

    [MenuItem("Tools/Setup/Update Packages")]
    public static void UpdatePackages() => PackageInstaller.UpdatePackages();
    
    [MenuItem("Tools/Setup/Install/Addressables")]
    public static void InstallAddressables() => PackageInstaller.InstallUnityPackage("com.unity.addressables");
    
    [MenuItem("Tools/Setup/Install/Burst")]
    public static void InstallBurst() => PackageInstaller.InstallUnityPackage("com.unity.burst");
    
    [MenuItem("Tools/Setup/Install/Cinemachine")]
    public static void InstallCinemachine() => PackageInstaller.InstallUnityPackage("com.unity.cinemachine");

    [MenuItem("Tools/Setup/Install/Device Simulator")]
    public static void InstallDeviceSimulator() => PackageInstaller.InstallUnityPackage("com.unity.device-simulator");

    [MenuItem("Tools/Setup/Install/Havok Physics")]
    public static void InstallHavokPhysics() => PackageInstaller.InstallUnityPackage("com.havok.physics");
    
    [MenuItem("Tools/Setup/Install/HDRP")]
    public static void InstallHdrp() => PackageInstaller.InstallUnityPackage("com.unity.render-pipelines.high-definition");
    
    [MenuItem("Tools/Setup/Install/Input System")]
    public static void InstallInputSystem() => PackageInstaller.InstallUnityPackage("com.unity.inputsystem");
    
    [MenuItem("Tools/Setup/Install/Jobs")]
    public static void InstallJobs() => PackageInstaller.InstallUnityPackage("com.unity.jobs");

    [MenuItem("Tools/Setup/Install/Memory Profiler")]
    public static void InstallMemoryProfiler() => PackageInstaller.InstallUnityPackage("com.unity.memoryprofiler");
    
    [MenuItem("Tools/Setup/Install/ML-Agents")]
    public static void InstallMlAgents() => PackageInstaller.InstallUnityPackage("com.unity.ml-agents");
    
    [MenuItem("Tools/Setup/Install/NetCode")]
    public static void InstallNetCode() => PackageInstaller.InstallUnityPackage("com.unity.netcode");
    
    [MenuItem("Tools/Setup/Install/PostProcessing")]
    public static void InstallPostProcessing() => PackageInstaller.InstallUnityPackage("com.unity.postprocessing");
    
    [MenuItem("Tools/Setup/Install/ProBuilder")]
    public static void InstallProBuilder() => PackageInstaller.InstallUnityPackage("com.unity.probuilder");
    
    [MenuItem("Tools/Setup/Install/ProGrids")]
    public static void InstallProGrids() => PackageInstaller.InstallUnityPackage("com.unity.progrids ");
    
    [MenuItem("Tools/Setup/Install/Recorder")]
    public static void InstallRecorder() => PackageInstaller.InstallUnityPackage("com.unity.recorder");

    [MenuItem("Tools/Setup/Install/URP")]
    public static void InstallUrp() => PackageInstaller.InstallUnityPackage("com.unity.render-pipelines.universal");

    [MenuItem("Tools/Setup/Install/VFX Graph")]
    public static void InstallVfxGraph() => PackageInstaller.InstallUnityPackage("com.unity.visualeffectgraph");
}