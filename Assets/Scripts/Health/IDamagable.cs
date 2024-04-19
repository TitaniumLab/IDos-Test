using System;

public interface IDamagable
{
    public event Action<int> OnDamageTacken;
    public event Action OnDeath;
    public enum Fraction
    {
        Player,
        Enemy
    }

    public Fraction UnitFraction { get; }

    public void TakeDamage(int damage);
}
