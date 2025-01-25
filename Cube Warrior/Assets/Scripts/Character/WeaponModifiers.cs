using Kryz.CharacterStats;

public class WeaponModifiers
{
    //  Multipliers
    public CharacterStat AttackSpeedMultiplier;
    public CharacterStat DamageMultiplier;
    public CharacterStat AreaMultiplier;
    
    // Additions
    public CharacterStat ExtraChains;

    public WeaponModifiers()
    {
        AttackSpeedMultiplier = new CharacterStat(1f);
        DamageMultiplier = new CharacterStat(1f);
        ExtraChains = new CharacterStat(2f);
        AreaMultiplier = new CharacterStat(1f);
    }
}