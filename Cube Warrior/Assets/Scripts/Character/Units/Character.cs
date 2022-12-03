using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine;

namespace Character
{
    public class Character : Unit
    {
        public List<Weapon> weapons = new List<Weapon>();

        protected override void Update()
        {
            HandleInput();
        }

        public override void Die()
        {
        }

        protected override void InitializeStats()
        {
            base.InitializeStats();
            CurrentStats.UnitModifiers.MovementSpeed.AddModifier(new StatModifier(10f, StatModType.PercentAdd));
            CurrentStats.WeaponModifiers.AttackSpeedMultiplier.AddModifier(new StatModifier(0.5f, StatModType.Flat));
            CurrentStats.TurretModifiers.weaponModifiers.AttackSpeedMultiplier.AddModifier(
                new StatModifier(10f, StatModType.Flat));

            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].Initialize(this, CurrentStats.WeaponModifiers);
            }
        }

        private void HandleInput()
        {
            Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

            Move(movementVector * Time.deltaTime, MovementSpeed);
        }
    }
}