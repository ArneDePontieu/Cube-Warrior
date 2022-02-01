using UnityEngine;

namespace Character
{
    public class Enemy : Unit
    {
        [SerializeField] private Character player;

        protected override void Update()
        {
            Move(player.transform.position - transform.position, MovementSpeed);
        }

        public override void Die()
        {
            Destroy(gameObject);
        }
    }
}