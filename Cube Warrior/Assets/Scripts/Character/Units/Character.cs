using TigerForge;
using UnityEngine;

namespace Character
{
    public static partial class EventNames
    {
        public const string PlayerCharacterDied = "PLAYER_DEATH";
    }

    public class Character : Unit, ILevelable
    {
        public float CurrentExperience { get; set; }
        public float CurrentLevel { get; set; }
        
        protected override void Update()
        {
            HandleInput();
        }

        public override void Die()
        {
            EventManager.EmitEvent(EventNames.PlayerCharacterDied);
        }

        private void HandleInput()
        {
            Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

            Move(movementVector * Time.deltaTime, MovementSpeed);
        }
    }
}