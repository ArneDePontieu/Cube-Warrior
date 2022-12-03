
public interface IDamageable
{
    float MaxHealth { get; }
    float CurrentHealth { get; set; }

    void TakeDamage(float amount, DamageType damageType);

    void Die();
}