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
            Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

            Move(movementVector * Time.deltaTime, MovementSpeed);
        }
    }
}