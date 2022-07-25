using System;
using UnityEngine;

public interface IInputService : IService
{
    Vector2 Direction { get; }
    
    event Action SpawnButtonClick;

    void EnableGameplayInput();
    void DisableGameplayInput();
}
