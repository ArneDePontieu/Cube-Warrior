using UnityEngine;

namespace Character
{
    public abstract class Unit : MonoBehaviour, IMoveable, IDamageable
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] protected UnitBaseStats baseStats;

        private UnitStats currentStats = new UnitStats();

        public float MovementSpeed => currentStats.movementSpeed.Value;

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
            Initialize();
        }

        private void Initialize()
        {
            currentStats.Initialize(baseStats);
            CurrentHealth = currentStats.maxHealth.Value;
        }

        public float MaxHealth => currentStats.maxHealth.Value;
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