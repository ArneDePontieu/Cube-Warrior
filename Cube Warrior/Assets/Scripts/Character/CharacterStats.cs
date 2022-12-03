using Character;
using Kryz.CharacterStats;

public class UnitStats
{
    public UnitModifiers UnitModifiers;
    // Projectiles

    // Turrets
    public TurretModifiers TurretModifiers;

    public WeaponModifiers WeaponModifiers;

    public void Initialize(UnitBaseStats baseStats)
    {
        UnitModifiers = new UnitModifiers(baseStats);
        TurretModifiers = new TurretModifiers();
        WeaponModifiers = new WeaponModifiers();
    }
}