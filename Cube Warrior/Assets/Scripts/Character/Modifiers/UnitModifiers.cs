using Character;
using Kryz.CharacterStats;

public class UnitModifiers 
{
    public CharacterStat MaxHealth;
    public CharacterStat MovementSpeed;

    public UnitModifiers(UnitBaseStats baseStats)
    {
        MaxHealth = new CharacterStat(baseStats.MaxHealth);
        MovementSpeed = new CharacterStat(baseStats.MovementSpeed);
    }
}
