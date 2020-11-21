using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointEffector2D))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionForceVariation;
    [SerializeField] private float _destroyingTime;

    private PointEffector2D _pointEffector;

    #region OnValidate
    private void OnValidate()
    {
        if (_explosionForce < 0)
            _explosionForce = 0;

        if (_explosionForceVariation < 0)
            _explosionForceVariation = 0;

        if (_destroyingTime < 0)
            _destroyingTime = 0;
    }
    #endregion
    private void OnEnable()
    {
        _pointEffector = GetComponent<PointEffector2D>();
        _pointEffector.forceMagnitude = _explosionForce;
        _pointEffector.forceVariation = _explosionForceVariation;

        _explosionEffect.SetActive(true);

        Destroy(gameObject, _destroyingTime);
    }
}
