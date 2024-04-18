using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponConfig", menuName = "Weapon Config", order = 51)]
public class WeaponConfig : ScriptableObject
{
    [field: SerializeField] public Transform WeaponPrefab { get; private set; }
    [field: SerializeField] public Bullet BulletPrefab { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField] public int BulletsPerShot { get; private set; }
    [field: SerializeField] public float SpreadEnlge { get; private set; }
    [field: SerializeField] public float BulletSpeed { get; private set; }
    [field: SerializeField] public float BulletLifeTime { get; private set; }
}
