using UnityEngine;

namespace Character
{
    public class Character : Unit
    {
        protected override void Update()
        {
            HandleInput();
        }

        public override void Die()
        {
            
        }

        private void HandleInput()
        {
            Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Move(movementVector * Time.deltaTime, MovementSpeed);
        }
    }
}