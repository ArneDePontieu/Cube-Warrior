using Character;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageDealer
{
    public Rigidbody rigidbody = null;

    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private float projectileSpeed = 5f;

    private float lifeTimeTimer = 0f;

    public float LifeTime
    {
        get => lifeTime;
        set => lifeTime = value;
    }

    public float ProjectileSpeed
    {
        get => projectileSpeed;
        set => projectileSpeed = value;
    }

    public float Damage { get; set; }


    protected void Update()
    {
        lifeTimeTimer += Time.deltaTime;

        if (lifeTimeTimer >= LifeTime)
        {
            Die();
        }
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(tag))
        {
            Die();
            return;
        }

        Unit target = other.collider.GetComponent<Unit>();

        if (!target)
        {
            return;
        }

        var damageable = target as IDamageable;
        damageable?.TakeDamage(Damage, DamageType.Physical);

        Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}