using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTriggerArea : MonoBehaviour
{
    public event Action<IDamagable, Transform> OnTriggetEnter;
    public event Action<Transform> OnTriggetExit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            OnTriggetEnter?.Invoke(damagable, collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            OnTriggetExit?.Invoke(collision.transform);
        }
    }
}
