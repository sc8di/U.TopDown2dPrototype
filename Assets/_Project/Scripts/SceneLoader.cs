using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    public void LoadScene(SceneType sceneType)
    {
        SceneManager.LoadSceneAsync(sceneType.GetSceneName(), LoadSceneMode.Single);
    }
}