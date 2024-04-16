using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletUnityPool 
{
    private Bullet _bulletPrefab;
    private Transform _parentTransform;
    private ObjectPool<Bullet> _pool;
    public BulletUnityPool(Bullet bulletPrefab, Transform poolsHandler, string creatorName)
    {
        _pool = new ObjectPool<Bullet>(CreateUnit, GetUnit, ReleaseUnit);
        Transform poolHandler =  new GameObject($"{creatorName} pool").transform;
        poolHandler.parent = poolsHandler;
        _parentTransform = poolHandler;
        _bulletPrefab = bulletPrefab;
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
        var bullet = Object.Instantiate(_bulletPrefab, _parentTransform);
        bullet.GetComponent<Bullet>().SetPool(_pool);
        return bullet;
    }

    private void GetUnit(Bullet bullet) =>
        bullet.gameObject.SetActive(true);

    private void ReleaseUnit(Bullet bullet) =>
        bullet.gameObject.SetActive(false);
}
