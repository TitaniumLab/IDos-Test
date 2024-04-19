using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [field: SerializeField] public WeaponConfig WeaponConfig { get; private set; }
    [SerializeField] protected Transform _weaponPosition;
    protected float _nextShotTime;
    [SerializeField] protected Transform poolsHandler;
    [field: SerializeField] public IDamagable.Fraction TargetFraction { get; private set; }
    protected BulletUnityPool _pool;
    protected IInput _input;


    protected virtual void Fire()
    {
        //_cachedTransform.up = direction;

        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + 1 / WeaponConfig.FireRate;
            for (int i = 0; i < WeaponConfig.BulletsPerShot; i++)
            {
                Bullet bullet = _pool.Get();
                bullet.transform.position = _weaponPosition.position;
                bullet.StartMove(GetDirection());
            }
        }
    }

    protected Quaternion GetDirection()
    {
        Quaternion rotation = Quaternion.identity;
        float spread = Random.Range(-WeaponConfig.SpreadEnlge, WeaponConfig.SpreadEnlge);
        rotation.eulerAngles = new Vector3(0, 0, _weaponPosition.eulerAngles.z + spread);
        return rotation;
    }
}
