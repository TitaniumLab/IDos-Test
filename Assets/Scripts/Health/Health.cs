using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [field: SerializeField] public IDamagable.Fraction UnitFraction { get; private set; }

    [field: SerializeField] public int Maxhealth { get; private set; }
    [field: SerializeField] public int Currenthealth { get; private set; }

    public event Action<int> OnDamageTacken;
    public event Action OnDeath;

    private void Awake()
    {
        Currenthealth = Maxhealth;
        OnDeath += Death;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Currenthealth -= damage;
            OnDamageTacken(Currenthealth);
        }
        if (Currenthealth <= 0)
            OnDeath();
    }

    private void Death()
    {
        this.gameObject.SetActive(false);
    }
}
