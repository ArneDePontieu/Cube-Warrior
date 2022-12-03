using System.Collections;
using System.Collections.Generic;
using Character;
using Kryz.CharacterStats;
using UnityEngine;

public class UnitStats
{
    public CharacterStat maxHealth;
    public CharacterStat movementSpeed;

    public void Initialize(UnitBaseStats baseStats)
    {
        maxHealth = new CharacterStat(baseStats.MaxHealth);
        movementSpeed = new CharacterStat(baseStats.MovementSpeed);
    }
}