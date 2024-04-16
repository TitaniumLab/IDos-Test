using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class MovementHandler : MonoBehaviour
{
    private IInput _playerInpur;
    private CharacterController _characterController;
    private Transform _cachedTransform;
    [SerializeField] private float _movementSpeed;

    [Inject]
    private void Construct(IInput playerInpur)
    {
        _playerInpur = playerInpur;
        _playerInpur.OnMove += MoveTo;
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _cachedTransform = GetComponent<Transform>();
    }


    private void MoveTo(Vector3 direction)
    {
        _characterController.Move(direction.normalized * Time.deltaTime * _movementSpeed);
        _cachedTransform.up = direction;
    }
}
