using System;
using UnityEngine;

public class DesktopInput : MonoBehaviour, IInput
{

    public event Action OnMove;
    public event Action<Vector3> OnRotation;
    public event Action OnFire;

    [SerializeField] private float vInput;
    [SerializeField] private float hInput;


    private void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(hInput, vInput);

        if (direction != Vector2.zero)
            OnRotation?.Invoke(direction);
        if (Input.GetMouseButton(0))
            OnFire?.Invoke();
        else if (direction != Vector2.zero)
            OnMove?.Invoke();
    }
}
