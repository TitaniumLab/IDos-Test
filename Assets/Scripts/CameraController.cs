using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _cameraOffset;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        _camera.transform.position = _playerTransform.position + _cameraOffset;
    }
}
