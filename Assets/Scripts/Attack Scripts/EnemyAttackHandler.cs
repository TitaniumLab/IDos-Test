using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(IInput))]
public class EnemyAttackHandler : AttackHandler
{

    private void Awake()
    {
        Instantiate(WeaponConfig.WeaponPrefab, _weaponPosition);
        _pool = new BulletUnityPool(this, poolsHandler, this.name);
        _input = GetComponent<IInput>();
        _input.OnFire += Fire;
    }
}
