using Kryz.CharacterStats;

public class TurretModifiers
{
    public WeaponModifiers weaponModifiers;
    public WeaponModifiers unitModifiers;

    public CharacterStat durationModifiers;

    public TurretModifiers()
    {
        weaponModifiers = new WeaponModifiers();
        unitModifiers = new WeaponModifiers();
        
        durationModifiers = new CharacterStat(1f);
    }
}