using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private IInputService _inputService;
    
    private PlayerAnimator _animator;
    private Rigidbody2D _rigidbody;
    private Transform _transform;

    private Vector2 _direction;
    private Vector3 _defaultLocalScale;
    private Vector3 _invertLocalScale;

    private void Start()
    {
        _inputService = ServiceLocator.Container.Single<IInputService>();;
        _inputService.EnableGameplayInput();
        
        _animator = new PlayerAnimator(GetComponent<Animator>());
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;

        _defaultLocalScale = _transform.localScale;
        _invertLocalScale = new Vector3(-_defaultLocalScale.x, _defaultLocalScale.y, _defaultLocalScale.z);
    }

    private void Update()
    {
        UpdateDirection();
        UpdateAnimationDirection();
        UpdateAnimationSpeed();
        Move();
        UpdateScaleByDirection();
    }

    private void UpdateDirection() 
        => _direction = _inputService.Direction;

    private void UpdateAnimationDirection() 
        => _animator.SetDirection(_direction.normalized);

    private void UpdateAnimationSpeed()
        => _animator.SetSpeed(_direction.sqrMagnitude);

    private void Move() 
        => _rigidbody.velocity = _direction.normalized * 
                                 (Mathf.Clamp(_direction.magnitude, 0.0f, 1.0f) * _moveSpeed);

    private void UpdateScaleByDirection()
    {
        if (_direction.x == 0.0f)
        {
            return;
        }
        
        _transform.localScale = _direction.x < 0.0f ? _invertLocalScale : _defaultLocalScale;
    }
}