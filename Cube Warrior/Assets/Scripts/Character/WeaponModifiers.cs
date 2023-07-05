using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine;

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