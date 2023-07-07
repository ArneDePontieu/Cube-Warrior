using Kryz.CharacterStats;

public class WeaponModifiers
{
    // Damage
    public CharacterStat AttackSpeedMultiplier;
    public CharacterStat DamageMultiplier;

    public WeaponModifiers()
    {
        AttackSpeedMultiplier = new CharacterStat(1f);
        DamageMultiplier = new CharacterStat(1f);
    }
}