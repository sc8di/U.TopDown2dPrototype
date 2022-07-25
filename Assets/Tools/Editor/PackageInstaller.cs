using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public static class PackageInstaller
{
    public static async Task ReplaceManifestFromGist(string id, string user = "sc8di")
    {
        var url = GetGistUrl(id, user);
        var content = await GetContent(url);
        ReplaceManifestFile(content);
    }

    public static async void UpdatePackages() // TODO: replace this with something smarter.
    {
        var packages = UnityEditor.PackageManager.Client.List();

        while (packages.IsCompleted == false)
        {
            if (packages.Error != null)
            {
                break;
            }
            
            Debug.Log("Wait for packages list request.");
            await Task.Yield();
        }

        foreach (var package in packages.Result)
        {
            var request = UnityEditor.PackageManager.Client.Add(package.name);
                
            while (request.IsCompleted == false)
            {
                if (request.Error != null)
                {
                    Debug.Log($"Error by {package.name}: {request.Error}.");
                    break;
                }
                
                Debug.Log($"Wait for {package.name}.");
                await Task.Yield();
            }
        }
        
        UnityEditor.PackageManager.Client.Resolve();
        Debug.Log("Update finished.");
    }
    
    public static void ResetPackagesToDefault() =>
        UnityEditor.PackageManager.Client.ResetToEditorDefaults();

    public static void InstallUnityPackage(string packageName) =>
        UnityEditor.PackageManager.Client.Add(packageName);
    
    private static string GetGistUrl(string id, string user) =>
        $"http://gist.githubusercontent.com/{user}/{id}/raw";

    private static async Task<string> GetContent(string url)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }

    private static void ReplaceManifestFile(string content)
    {
        var manifest = Path.Combine(Application.dataPath, "../Packages/manifest.json");
        File.WriteAllText(manifest, content);
        UnityEditor.PackageManager.Client.Resolve();
    }
}