using UnityEngine;

[RequireComponent(typeof(IInput))]
public class EnemyMovement : MovementHandler
{
    private void Awake()
    {
        _input = GetComponent<IInput>();
        _input.OnMove += MoveTo;
        _input.OnRotation += Direction;

        _rigidbody = GetComponent<Rigidbody2D>();
        _cachedTransform = GetComponent<Transform>();
    }
}
