using UnityEngine;

[CreateAssetMenu(fileName = "WeaponBaseStats", menuName = "ScriptableObjects/WeaponBaseStats", order = 1)]
public class WeaponBaseStats : ScriptableObject
{
    public float damage;
    public float triggerDelay;
    public float lifeTime;
    public float speed;
}