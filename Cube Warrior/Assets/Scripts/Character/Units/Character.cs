using TigerForge;
using UnityEngine;

namespace Character
{
    public static partial class EventNames
    {
        public const string PlayerCharacterDied = "PLAYER_DEATH";
        public const string PlayerCharacterLeveled = "PLAYER_LEVELLED";
    }

    public class Character : Unit, ILevelable
    {
        public float CurrentExperience { get; set; }
        public float CurrentLevel { get; set; }

        private int requiredExperiencePerLevel = 1;
        
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
        
        public void GiveExperience(float amount)
        {
            CurrentExperience += amount;

            while (CurrentExperience >= requiredExperiencePerLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            CurrentExperience -= requiredExperiencePerLevel;
            CurrentLevel++;
            EventManager.EmitEvent(EventNames.PlayerCharacterLeveled);
        }
    }
}