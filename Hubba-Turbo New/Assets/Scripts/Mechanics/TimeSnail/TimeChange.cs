using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemCollision))]
[RequireComponent(typeof(TimeSnailPresenter))]
public class TimeChange : MonoBehaviour
{
    [SerializeField] private AbstractSnailType _slowingSnail;
    [SerializeField] private AbstractSnailType _acceleratingSnail;

    private ItemCollision _itemCollision;
    private TimeSnailPresenter _timeSnailPresenter;
    private Side _currentSide;
    private bool _isTimeFirstTimeChanged;

    private void Start()
    {
        _itemCollision = GetComponent<ItemCollision>();
        _timeSnailPresenter = GetComponent<TimeSnailPresenter>();
    }

    private void Update()
    {
        var side = _itemCollision.Side;

        FirstTimeChangeTime(side);

        if (side != _currentSide)
        {
            _currentSide = side;
            ChangeTime(side);
        }

        
    }

    private void OnDestroy()
    {
        SetNormalTime();
    }

    private void FirstTimeChangeTime(Side side)
    {
        if (_isTimeFirstTimeChanged == false)
        {
            ChangeTime(side);
            _isTimeFirstTimeChanged = true;
        }
    }

    private void ChangeTime(Side side)
    {
        if (side == _slowingSnail.ActivationSide)
        {
            _slowingSnail.ChangeTime();
            _timeSnailPresenter.Present(_slowingSnail);
        }

        if (side == _acceleratingSnail.ActivationSide)
        {
            _acceleratingSnail.ChangeTime();
            _timeSnailPresenter.Present(_acceleratingSnail);
        }
    }

    private void SetNormalTime()
    {
        Time.timeScale = 1f;
    }
}
