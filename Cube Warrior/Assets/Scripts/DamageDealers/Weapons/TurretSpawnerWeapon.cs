using Character;
using UnityEngine;

public class TurretSpawnerWeapon : Weapon
{
    [SerializeField] private Unit turretPrefab;

    protected override void TriggerWeapon()
    {
        var turretUnit = Instantiate(turretPrefab, transform.position, Quaternion.identity);
    }
}