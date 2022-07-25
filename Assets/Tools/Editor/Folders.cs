using System.IO;
using UnityEngine;

public static class Folders
{
    public static void CreateDirectories(string root, params string[] directories)
    {
        var fullPath = Path.Combine(Application.dataPath, root);
        foreach (var directory in directories)
        {
            Directory.CreateDirectory(Path.Combine(fullPath, directory));
        }
    }
}