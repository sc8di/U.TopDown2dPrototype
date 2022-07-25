using System;
using UnityEngine;

public class InputService : IInputService
{
    private InputActions _input;

    public InputService()
    {
        _input = new InputActions();
        _input.UI.Enable();
        _input.Gameplay.SpawnNpc.performed += context => SpawnButtonClick?.Invoke();
    }

    public Vector2 Direction => _input.Gameplay.Movement.ReadValue<Vector2>();
    public event Action SpawnButtonClick;

    public void EnableGameplayInput()
    {
        _input.UI.Disable();
        _input.Gameplay.Enable();
    }

    public void DisableGameplayInput()
    {
        _input.Gameplay.Disable();
        _input.UI.Enable();
    }
}