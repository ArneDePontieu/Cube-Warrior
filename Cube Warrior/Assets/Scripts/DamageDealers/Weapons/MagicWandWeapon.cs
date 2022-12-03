using Character;
using UnityEngine;

public class MagicWandWeapon : Weapon
{
    [SerializeField] private Projectile projectilePrefab;

    protected override void TriggerWeapon()
    {
        var enemies = FindObjectsOfType<Enemy>();
        (float, Enemy) closestEnemy = (int.MaxValue, null);

        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(enemies[i].transform.position, transform.position);
            if (closestEnemy.Item1 <= distance)
            {
                continue;
            }

            closestEnemy = (distance, enemies[i]);
        }

        if (closestEnemy.Item2 == null)
        {
            return;
        }

        ShootProjectile(closestEnemy.Item2.transform.position - transform.position);
    }

    private void ShootProjectile(Vector3 targetDirection)
    {
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        lookRotation.x = 0;
        lookRotation.y = 0;

        Projectile projectile = Instantiate(projectilePrefab, transform.position + (targetDirection.normalized * 0.2f),
            lookRotation);

        projectile.LifeTime = stats.lifeTime;
        projectile.Damage = stats.damage;
        projectile.rigidbody.velocity = targetDirection.normalized * projectile.ProjectileSpeed;
    }
}