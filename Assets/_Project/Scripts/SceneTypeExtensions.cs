using System;

public static class SceneTypeExtensions
{
    public static string GetSceneName(this SceneType sceneType)
    {
        return sceneType switch
        {
            SceneType.Prototype => "Prototype",
            SceneType.Launcher => "Launcher",
            _ => throw new ArgumentOutOfRangeException(nameof(sceneType), sceneType, null)
        };
    }
}