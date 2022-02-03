using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAura :MonoBehaviour, IDamageDealer
{
    [SerializeField] private float damage=10f;
    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    protected void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(tag))
        {
            return;
        }
        
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(Damage * Time.deltaTime, DamageType.Physical);
    }
}
