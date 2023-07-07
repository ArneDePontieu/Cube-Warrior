using Character;
using UnityEngine;

public class TurretUnit : Unit
{
    [SerializeField] private Weapon weapon;

    private TurretUnitStats turretStats;
    private float duration;
    private Unit owner;

    public void Initialize(Unit owner)
    {
        this.owner = owner;

        weapon.Initialize(this, owner.CurrentStats.TurretModifiers.weaponModifiers);
    }

    protected override void Awake()
    {
        base.Awake();

        if (baseStats is TurretUnitStats turretUnitStats)
        {
            turretStats = turretUnitStats;
        }
    }

    protected virtual void Update()
    {
        if (turretStats == null)
        {
            return;
        }

        duration += Time.deltaTime;

        if (duration >= (owner.CurrentStats.TurretModifiers.durationModifiers.Value * turretStats.duration))
        {
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}