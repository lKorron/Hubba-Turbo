using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCircleMovement : AbstractСyclicalMovement
{
    public override void Move(GameObject gameObject, float speed, float radius, Vector2 centerPoint)
    {
        _moveValue += Time.deltaTime * speed;

        float xPosition = radius * Mathf.Sin(_moveValue) + centerPoint.x;
        float yPosition = radius * Mathf.Cos(_moveValue) + centerPoint.y;

        gameObject.transform.position = new Vector3(xPosition, yPosition, 0);
    }
}
