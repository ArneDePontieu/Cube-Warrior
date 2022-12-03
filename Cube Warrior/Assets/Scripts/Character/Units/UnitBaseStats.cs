using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "UnitBaseStats", menuName = "ScriptableObjects/UnitStats", order = 1)]
    public class UnitBaseStats : ScriptableObject
    {
        public float MaxHealth;
        public float MovementSpeed;
        public float Damage;
    }
}
