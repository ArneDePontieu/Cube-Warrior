﻿
public interface IDamageable
{
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }

    void TakeDamage(float amount, DamageType damageType);

    void Die();
}