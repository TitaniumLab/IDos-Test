using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IDamagable
{
    public enum Fraction
    {
        Player,
        Enemy
    }

    public Fraction UnitFraction { get; }

    public void TakeDamage(int damage);
}
