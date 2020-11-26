using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _centerPoint;

    private float _moveValue;

    private void Update()
    {
        Fly();
    }

    private void Fly()
    {
        _moveValue += Time.deltaTime * _speed;

        float xPosition = _radius * Mathf.Cos(_moveValue) + _centerPoint.x;
        float yPosition = _radius * Mathf.Sin(_moveValue) + _centerPoint.y;

        transform.position = new Vector3(xPosition, yPosition, 0);
    }
}
