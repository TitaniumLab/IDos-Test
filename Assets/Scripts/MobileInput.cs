using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class MobileInput : MonoBehaviour, IInput
{
    private PlayerInput _playerInput;
    public event Action<Vector3> OnMove;
    [SerializeField] private Vector2 _direction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        _direction = _playerInput.actions["Move"].ReadValue<Vector2>();
        if (_direction != Vector2.zero)
            OnMove?.Invoke(_direction);
    }
}
