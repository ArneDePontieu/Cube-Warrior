using Character;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [SerializeField] private Projectile projectilePrefab;

    protected override void TriggerWeapon()
    {
        Enemy enemy = FindClosestEnemy();
        
        if (enemy == null)
        {
            return;
        }
        
        ShootProjectileAtTarget(enemy);
    }

    private Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
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

        return closestEnemy.Item2;
    }

    private void ShootProjectileAtTarget(Enemy target)
    {
        Vector3 direction = target.transform.position - transform.position;
        
        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        Projectile projectile = Instantiate(projectilePrefab, transform.position + (direction.normalized * 1.28f),
            Quaternion.Euler(0f, 0f, angle));

        projectile.Initialize(stats, Modifiers, target);
    }
}