using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicalMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    [SerializeField] private Vector2 _centerPoint;
    [SerializeField] private AbstractСyclicalMovement _cyclicalMovement;

    private void Update()
    {
        _cyclicalMovement.Move(this.gameObject, _speed, _radius, _centerPoint);
    }

}
