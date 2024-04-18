using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifebarController : MonoBehaviour
{
    [SerializeField] private Canvas _lifebarPreset;
    [SerializeField] private Vector3 _offset;
    private Transform _transform;
    private Transform _cameraTransform;
    private Slider _slider;

    private void Awake()
    {
        _transform = Instantiate(_lifebarPreset, this.transform).transform;

        _cameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        _transform.position = transform.position + _offset;
        _transform.LookAt(_cameraTransform);
    }
}
