using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [field: SerializeField] public IDamagable.Fraction UnitFraction { get; private set; }

    [SerializeField] private int _maxhealth;
    [SerializeField] private int _currenthealth;

    private void Awake()
    {
        _currenthealth = _maxhealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currenthealth -= damage;
        }
    }
}
