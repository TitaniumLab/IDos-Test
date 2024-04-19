using UnityEngine;
using UnityEngine.Pool;

public class BulletUnityPool
{
    private Bullet _bulletPrefab;
    private Transform _parentTransform;
    private ObjectPool<Bullet> _pool;
    private AttackHandler _attackHandler;
    public BulletUnityPool(AttackHandler attackHandler, Transform poolsHandler, string creatorName)
    {
        _pool = new ObjectPool<Bullet>(CreateUnit, GetUnit, ReleaseUnit);
        Transform poolHandler = new GameObject($"{creatorName} pool").transform;
        poolHandler.parent = poolsHandler;
        _parentTransform = poolHandler;
        _attackHandler = attackHandler;
        _bulletPrefab = attackHandler.WeaponConfig.BulletPrefab;
    }

    public Bullet Get()
    {
        return _pool.Get();
    }

    public void Release(Bullet bullet)
    {
        _pool.Release(bullet);
    }

    private Bullet CreateUnit()
    {
        Bullet bullet = Object.Instantiate(_bulletPrefab, _parentTransform);
        bullet.SetPool(_pool);
        bullet.SetWeapon(_attackHandler);
        return bullet;
    }

    private void GetUnit(Bullet bullet) =>
        bullet.gameObject.SetActive(true);

    private void ReleaseUnit(Bullet bullet) =>
        bullet.gameObject.SetActive(false);
}
