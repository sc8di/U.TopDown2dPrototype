using UnityEngine;

public class PlayerAnimator
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    
    private Animator _animator;

    public PlayerAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void SetSpeed(float value)
    {
        _animator.SetFloat(Speed, value);
    }

    public void SetDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return;
        }
        
        _animator.SetFloat(Horizontal, direction.x);
        _animator.SetFloat(Vertical, direction.y);
    }
}