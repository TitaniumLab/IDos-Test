using UnityEngine;
using Zenject;

public class PlayerMovement  : MovementHandler
{
    [Inject]
    private void Construct(IInput playerInpur)
    {
        _input = playerInpur;
        _input.OnMove += MoveTo;
        _input.OnRotation += Direction;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _cachedTransform = GetComponent<Transform>();
    }
}
