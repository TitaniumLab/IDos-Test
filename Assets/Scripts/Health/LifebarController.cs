using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class LifebarController : MonoBehaviour
{
    [SerializeField] private Canvas _lifebarPreset;
    [SerializeField] private Vector3 _offset;
    private Health _health;
    private Transform _transform;
    private Transform _cameraTransform;
    private Slider _slider;

    private void Start()
    {
        _transform = Instantiate(_lifebarPreset, this.transform).transform;
        _cameraTransform = Camera.main.transform;
        _health = GetComponent<Health>();
        _slider = GetComponentInChildren<Slider>();
        _slider.maxValue = _health.Maxhealth;
        _slider.value = _health.Currenthealth;
        _health.OnDamageTacken += ChangeValue;
    }

    private void LateUpdate()
    {
        _transform.position = transform.position + _offset;
        _transform.LookAt(_cameraTransform);
    }

    private void ChangeValue(int value)
    {
        _slider.value = value;
    }
}
