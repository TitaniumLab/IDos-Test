using System;
using UnityEngine;

public interface IInput
{
    public event Action OnMove;
    public event Action<Vector3> OnRotation;
    public event Action OnFire;
}
