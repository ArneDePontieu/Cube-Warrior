using Character;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour, IDamageDealer
{
    public Rigidbody2D rigidbody = null;

    [SerializeField] private float lifeTime = 5f;

    public float LifeTime
    {
        get => lifeTime;
        set => lifeTime = value;
    }
    
    public float HomingStrength
    {
        get;
        private set;
    }

    public float ProjectileSpeed { get; set; }
    public float Damage { get; set; }

    private float lifeTimeTimer;

    // Chains
    private float remainingChains = 0f;
    private FixedQueue<Enemy> targetHistory = new(3); // to prevent chaining between the same two targets
    private Enemy currentTarget;

    private bool isDead;

    public void Initialize(WeaponBaseStats baseStats, WeaponModifiers modifiers, Enemy target)
    {
        LifeTime = baseStats.lifeTime;
        Damage = baseStats.damage * modifiers.DamageMultiplier.Value;
        remainingChains = baseStats.chains + modifiers.ExtraChains.Value;
        ProjectileSpeed = baseStats.projectileSpeed;
        HomingStrength = baseStats.homingStrength;
        targetHistory.Enqueue(target);

        ShootToDirection(target.transform.position - transform.position);
    }

    protected void Update()
    {
        lifeTimeTimer += Time.deltaTime;

        if (lifeTimeTimer >= LifeTime)
        {
            Die();
        }
    }

    protected void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        if (currentTarget == null)
        {
            return;
        }

        // Calculate direction to target
        Vector2 direction = (currentTarget.transform.position - transform.position).normalized;

        // Interpolate between current direction and target direction
        Vector2 newDirection = Vector2.Lerp(rigidbody.linearVelocity.normalized, direction, HomingStrength * Time.deltaTime);
        Vector2 velocity = newDirection * ProjectileSpeed;

        rigidbody.linearVelocity = velocity;
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        rigidbody.rotation = angle;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tag))
        {
            // Die();
            return;
        }

        Unit target = other.GetComponent<Unit>();

        if (!target)
        {
            return;
        }

        IDamageable damageable = target;
        damageable.TakeDamage(Damage, DamageType.Physical);

        bool isChaining = false;

        if (remainingChains >= 1f || Random.value <= remainingChains)
        {
            isChaining = true;
            remainingChains -= 1f;
        }

        if (isChaining)
        {
            if (!TryFindNextTarget(out var nextTarget))
            {
                currentTarget = null;
                return;
            }

            targetHistory.Enqueue(nextTarget);
            currentTarget = nextTarget;

            ShootToDirection(nextTarget.transform.position - transform.position);
            return;
        }

        Die();
    }

    protected bool TryFindNextTarget(out Enemy target)
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        (float, Enemy) closestEnemy = (int.MaxValue, null);

        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i];

            if (targetHistory.Contains(enemy))
            {
                continue;
            }

            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (closestEnemy.Item1 <= distance)
            {
                continue;
            }

            closestEnemy = (distance, enemy);
        }

        target = closestEnemy.Item2 ? closestEnemy.Item2 : default;

        return closestEnemy.Item2 != null;
    }

    protected virtual void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    private void ShootToDirection(Vector3 direction)
    {
        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation to the bullet
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        rigidbody.linearVelocity = direction.normalized * ProjectileSpeed;
    }
}