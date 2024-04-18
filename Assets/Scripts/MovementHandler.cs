using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementHandler : MonoBehaviour
{
    protected IInput _input;
    protected Rigidbody2D _rigidbody;
    protected Transform _cachedTransform;
    [SerializeField] protected float _movementSpeed;

    protected virtual void Direction(Vector3 direction)
    {
        _cachedTransform.up = direction.normalized;
    }

    protected virtual void MoveTo()
    {
        _rigidbody.velocity = _cachedTransform.up * _movementSpeed;
    }
}
