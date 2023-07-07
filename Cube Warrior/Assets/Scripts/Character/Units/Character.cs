using System.Collections.Generic;
using Kryz.CharacterStats;
using TigerForge;
using UnityEngine;

namespace Character
{
    public static partial class EventNames
    {
        public const string PlayerCharacterDied = "PLAYER_DEATH";
    }

    public class Character : Unit
    {
        public List<Weapon> weapons = new();

        protected override void Update()
        {
            HandleInput();
        }

        public override void Die()
        {
            EventManager.EmitEvent(EventNames.PlayerCharacterDied);
        }

        protected override void InitializeStats()
        {
            base.InitializeStats();

            for (int i = 0; i < weapons.Count; i++)
            {
                if (!weapons[i])
                {
                    return;
                }

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