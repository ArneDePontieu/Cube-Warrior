using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public abstract class Unit : MonoBehaviour, IMoveable, IDamageable
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] protected UnitBaseStats baseStats;

        public UnitStats CurrentStats = new();
        public List<Weapon> weapons = new();
        
        public float MovementSpeed => CurrentStats.UnitModifiers.MovementSpeed.Value;

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
            InitializeStats();
        }

        protected virtual void InitializeStats()
        {
            CurrentStats.Initialize(baseStats);
            CurrentHealth = CurrentStats.UnitModifiers.MaxHealth.Value;
            
            for (int i = 0; i < weapons.Count; i++)
            {
                if (!weapons[i])
                {
                    return;
                }

                weapons[i].Initialize(this, CurrentStats.WeaponModifiers);
            }
        }

        public float MaxHealth => CurrentStats.UnitModifiers.MaxHealth.Value;
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