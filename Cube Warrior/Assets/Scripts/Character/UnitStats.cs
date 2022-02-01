using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "UnitStats", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
    public class UnitStats : ScriptableObject
    {
        public float MaxHealth;
        public float MovementSpeed;
        public float Damage;
    }
}
