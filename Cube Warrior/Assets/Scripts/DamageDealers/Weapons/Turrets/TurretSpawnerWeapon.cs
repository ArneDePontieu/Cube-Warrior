using Character;
using UnityEngine;

public class TurretSpawnerWeapon : Weapon
{
    [SerializeField] private TurretUnit turretPrefab;

    protected override void TriggerWeapon()
    {
        TurretUnit turretUnit = Instantiate(turretPrefab, transform.position, Quaternion.identity);
        turretUnit.Initialize(stats.lifeTime);
    }
}