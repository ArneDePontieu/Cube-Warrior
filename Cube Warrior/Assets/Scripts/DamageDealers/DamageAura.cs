using System.Collections.Generic;
using UnityEngine;

public class DamageAura : Weapon
{
    private List<IDamageable> enemyList = new();

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tag))
        {
            return;
        }

        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        enemyList.Add(damageable);
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tag))
        {
            return;
        }

        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        enemyList.Remove(damageable);
    }

    protected override void TriggerWeapon()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i]?.TakeDamage(stats.damage * Modifiers.DamageMultiplier.Value, DamageType.Physical);
        }
    }
}