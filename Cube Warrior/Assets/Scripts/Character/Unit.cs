using UnityEngine;

namespace Character
{
    public abstract class Unit : MonoBehaviour, IMoveable, IDamageable
    {
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] protected UnitStats stats;

        public float MovementSpeed { get; set; }

        public void Move(Vector3 direction, float speed)
        {
            Vector3 movementVector = direction.normalized * speed;
            rigidBody.velocity = movementVector;
        }

        protected virtual void Update()
        {
        }

        protected virtual void Awake()
        {
            MovementSpeed = stats.MovementSpeed;
            MaxHealth = stats.MaxHealth;
            CurrentHealth = MaxHealth;
        }

        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }

        public void TakeDamage(float amount, DamageType damageType)
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public abstract void Die();
    }
}