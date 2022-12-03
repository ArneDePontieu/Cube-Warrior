using UnityEngine;

[CreateAssetMenu(fileName = "WeaponBaseStats", menuName = "ScriptableObjects/WeaponBaseStats", order = 1)]
public class WeaponBaseStats : ScriptableObject
{
   [SerializeField] public float damage;
   [SerializeField] public float triggerDelay;
   [SerializeField] public float lifeTime;
   [SerializeField] public float speed;
}