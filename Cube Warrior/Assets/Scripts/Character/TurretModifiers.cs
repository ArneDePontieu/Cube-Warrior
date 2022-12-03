using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine;

public class TurretModifiers 
{
    public WeaponModifiers weaponModifiers;
    public WeaponModifiers unitModifiers;

    public TurretModifiers()
    {
        weaponModifiers = new WeaponModifiers();
        unitModifiers = new WeaponModifiers();
    }
}
