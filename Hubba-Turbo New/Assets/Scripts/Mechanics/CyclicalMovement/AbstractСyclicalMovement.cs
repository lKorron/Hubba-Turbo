using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractСyclicalMovement: MonoBehaviour
{
    protected float _moveValue;

    public abstract void Move(GameObject gameObject, float speed, float radius, Vector2 centerPoint);
}
