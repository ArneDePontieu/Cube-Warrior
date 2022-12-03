using Character;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponBaseStats stats;

    protected float abilityTriggerTimer;

    protected virtual float TriggerSpeedMultiplier => Modifiers.AttackSpeedMultiplier.Value;
    protected Unit Owner;
    protected WeaponModifiers Modifiers;

    private float TriggerDelay => stats.triggerDelay;

    public virtual void Initialize(Unit owner, WeaponModifiers modifiers)
    {
        Owner = owner;
        Modifiers = modifiers;
    }

    protected virtual void Update()
    {
        if (!Owner)
        {
            return;
        }

        if (TriggerDelay == 0f)
        {
            return;
        }

        abilityTriggerTimer += Time.deltaTime * TriggerSpeedMultiplier;

        if (abilityTriggerTimer < TriggerDelay)
        {
            return;
        }

        abilityTriggerTimer -= TriggerDelay;

        TriggerWeapon();
    }

    protected abstract void TriggerWeapon();
}