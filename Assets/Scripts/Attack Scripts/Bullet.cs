using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private ObjectPool<Bullet> _pool;
    private AttackHandler _attackHandler;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IAgro agro))
            agro.Agro(_attackHandler.transform.position);

        if (!collision.TryGetComponent(out Bullet bullet) && gameObject.activeSelf)
        {
            if (collision.TryGetComponent(out IDamagable damagable) &&
                damagable.UnitFraction == _attackHandler.TargetFraction)
            {
                damagable.TakeDamage(_attackHandler.WeaponConfig.Damage);
            }

            if (!collision.isTrigger)
                _pool.Release(this);
        }
    }

    private void OnEnable()
    {
        _rb.velocity = Vector3.zero;
    }

    public void SetPool(ObjectPool<Bullet> pool)
    {
        _pool = pool;
    }
    public void SetWeapon(AttackHandler attackHandler)
    {
        if (_attackHandler is null)
            _attackHandler = attackHandler;
    }

    public void StartMove(Quaternion quaternion)
    {
        transform.rotation = quaternion;
        _rb.AddForce(transform.up * _attackHandler.WeaponConfig.BulletSpeed, ForceMode2D.Impulse);
    }
}
