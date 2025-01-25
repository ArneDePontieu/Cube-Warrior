using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "WeaponBaseStats", menuName = "ScriptableObjects/WeaponBaseStats", order = 1)]
public class WeaponBaseStats : ScriptableObject
{
   [SerializeField] public float damage;
   [SerializeField] public float triggerDelay;
   [SerializeField] public float lifeTime;
   [FormerlySerializedAs("speed")] [SerializeField] public float projectileSpeed;
   [SerializeField] public float chains=0f;
   [SerializeField] public float homingStrength=0f;
}