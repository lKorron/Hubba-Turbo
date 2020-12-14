using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemCollision))]
public class TimeChange : MonoBehaviour
{
    [SerializeField] private float _acceleratedTimeScale;
    [SerializeField] private float _slowedTimeScale;

    private ItemCollision _itemCollision;
    private Side _currentSide;

    public event Action SideChanged;

    public Side CurrentSide => _currentSide;

    #region OnValidate
    private void OnValidate()
    {
        if (_acceleratedTimeScale < 1)
            _acceleratedTimeScale = 1;

        if (_slowedTimeScale > 1 || _slowedTimeScale < 0)
            _slowedTimeScale = 0;
    }
    #endregion

    private void Start()
    {
        _itemCollision = GetComponent<ItemCollision>();
    }

    private void Update()
    {
        var side = _itemCollision.Side;

        if (side != _currentSide)
        {
            _currentSide = side;
            SideChanged.Invoke();
        }

        if (_currentSide == Side.Player)
        {
            SetTimeScale(_acceleratedTimeScale);
        }

        if (_currentSide == Side.Computer)
        {
            SetTimeScale(_slowedTimeScale);
        }
    }

    private void OnDestroy()
    {
        SetTimeScale(1f);
    }

    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
