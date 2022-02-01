using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Enemy : MonoBehaviour, IMoveable
    {
        [SerializeField] private Character player;
        [SerializeField] private Rigidbody rigidBody;

        public float MovementSpeed { get; set; }

        public void Move(Vector3 direction, float speed)
        {
            Vector3 movementVector = direction.normalized * speed;
            rigidBody.velocity = movementVector;
        }

        private void Update()
        {
            Move(player.transform.position - transform.position, MovementSpeed);
        }

        private void Awake()
        {
            MovementSpeed = 3f;
        }
    }
}