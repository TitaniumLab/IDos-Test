using System;
using UnityEngine;

public class DesktopInput : MonoBehaviour, IInput
{
    public event Action<Vector3> OnMove;
    private float vInput;
    private float hInput;

    private void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(hInput, vInput);
        if (direction != Vector2.zero)
            OnMove?.Invoke(direction);
    }
}
