
using UnityEngine;

public interface IMoveable
{
    float MovementSpeed { get; }
    
    void Move(Vector3 direction, float speed);
}