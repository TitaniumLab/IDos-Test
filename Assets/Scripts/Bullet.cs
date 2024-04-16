using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    private Collider2D _bulletCollider;
    private ObjectPool<Bullet> _pool;

    private void Awake()
    {
        _bulletCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Bullet bullet))
        {
            if (collision.TryGetComponent(out IDamagable damagable))
                damagable.TakeDamage(1);

            _pool.Release(this);
        }
    }

    public void SetPool(ObjectPool<Bullet> pool)
    {
        _pool = pool;
    }
}
