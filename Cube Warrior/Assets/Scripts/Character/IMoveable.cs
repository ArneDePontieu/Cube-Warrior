using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    float MovementSpeed { get; set; }
    
    void Move(Vector3 direction, float speed);
}