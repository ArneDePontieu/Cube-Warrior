using System;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour, IMoveable, IDamageable
    {
        [SerializeField] private Rigidbody characterController;

        public float MovementSpeed { get; set; }

        private void Awake()
        {
            MovementSpeed = 10f;
        }

        public void Move(Vector3 direction, float speed)
        {
            Vector3 movementVector = direction.normalized * speed;
            characterController.velocity = movementVector;
            Debug.Log($"Moving -> {movementVector}");
        }

        public void TakeDamage(float amount, DamageType damageType)
        {
            throw new System.NotImplementedException();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Move(movementVector * Time.deltaTime, MovementSpeed);
        }
    }
}