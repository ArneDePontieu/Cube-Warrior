using System.Collections.Generic;
using Character;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DamageAura : Weapon
{
    private List<IDamageable> enemyList = new();
    private Vector3 startScale = Vector3.one;
    
    public override void Initialize(Unit owner, WeaponModifiers modifiers)
    {
        base.Initialize(owner, modifiers);
        
        startScale = transform.localScale;
    }
    
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

    protected override void Update()
    {
        base.Update();

        if (Modifiers == null)
        {
            return;
        }
        
        transform.localScale = startScale * Modifiers.AreaMultiplier.Value;
    }
}