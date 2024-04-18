using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using Zenject;

public class PlayerAttackHandler : AttackHandler
{
    [Inject]
    private void Construct(IInput playerInput)
    {
        _input = playerInput;
    }

    private void Awake()
    {
        Instantiate(WeaponConfig.WeaponPrefab, _weaponPosition);
        _pool = new BulletUnityPool(this, poolsHandler, this.name);
        _input.OnFire += Fire;
    }
}
