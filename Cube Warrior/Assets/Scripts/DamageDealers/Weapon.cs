using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponBaseStats stats;

    protected float abilityTriggerTimer;

    protected virtual void Update()
    {
        if (stats.triggerDelay == 0f)
        {
            return;
        }

        abilityTriggerTimer += Time.deltaTime;

        if (abilityTriggerTimer < stats.triggerDelay)
        {
            return;
        }

        abilityTriggerTimer -= stats.triggerDelay;

        TriggerWeapon();
    }

    protected abstract void TriggerWeapon();
}