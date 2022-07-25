using UnityEngine;

public class Launcher : MonoBehaviour
{
    private ServiceLocator _serviceLocator;
    
    private void Awake()
    {
        _serviceLocator = ServiceLocator.Container;
        
        DontDestroyOnLoad(this);
        
        _serviceLocator.RegisterSingle<IInputService>(new InputService());
        _serviceLocator.RegisterSingle<ISceneLoader>(new SceneLoader());

        var sceneLoader = _serviceLocator.Single<ISceneLoader>();
        sceneLoader.LoadScene(SceneType.Prototype);
    }
}