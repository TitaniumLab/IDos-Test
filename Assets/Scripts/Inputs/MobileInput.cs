using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class MobileInput : MonoBehaviour, IInput
{
    private PlayerInput _playerInput;
    private bool _isFire = false;
    private InputAction _fireButtonAction;
    public event Action OnMove;
    public event Action OnFire;
    public event Action<Vector3> OnRotation;

    [SerializeField] private Transform _inputStick;
    [SerializeField] private Transform _inputButton;
    [SerializeField] private Vector2 _direction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _fireButtonAction = _playerInput.actions["Fire"];
    }

    private void OnEnable()
    {
        _inputStick.gameObject.SetActive(true);
        _inputButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        _direction = _playerInput.actions["Move"].ReadValue<Vector2>();

        if (_direction != Vector2.zero)
            OnRotation?.Invoke(_direction);
        if (_fireButtonAction.IsPressed())
            OnFire?.Invoke();
        else if (_direction != Vector2.zero)
            OnMove?.Invoke();
    }
}
