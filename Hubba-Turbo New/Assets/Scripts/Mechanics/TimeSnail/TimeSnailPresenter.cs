using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(TimeChange))]
public class TimeSnailPresenter : MonoBehaviour
{
    [SerializeField] private Sprite _slowingNailSprite;
    [SerializeField] private Sprite _acceleratingNailSprite;

    private SpriteRenderer _currentSprite;
    private TimeChange _timeChange;

    private void Start()
    {
        _currentSprite = GetComponent<SpriteRenderer>();
        _timeChange = GetComponent<TimeChange>();

        _timeChange.SideChanged += () => SetSprite();
    }

    private void OnDisable()
    {
        _timeChange.SideChanged -= () => SetSprite();
    }

    private void SetSprite()
    {
        
    }
}
