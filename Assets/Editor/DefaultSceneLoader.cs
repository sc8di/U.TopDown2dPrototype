#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.SceneManagement;

public class DefaultSceneLoader : EditorWindow
{
    static DefaultSceneLoader()
    {
        EditorApplication.playModeStateChanged += LoadDefaultScene;
    }

    static void LoadDefaultScene(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            SceneManager.LoadScene(SceneType.Launcher.GetSceneName());
        }
    }
}
#endif