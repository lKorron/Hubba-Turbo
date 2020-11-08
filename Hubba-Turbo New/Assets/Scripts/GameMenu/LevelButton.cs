using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour, IComparable
{
    [SerializeField] private int _levelNumber;

    private LevelButtonStars _levelButtonStars;
    private LevelChoice _levelChoice;
    private Button _button;
    private UnityAction _goToLevel;


    private void Awake()
    {

        _button = GetComponent<Button>();
        _levelButtonStars = GetComponentInChildren<LevelButtonStars>();
        _levelChoice = LevelChoice.Instance;

        _goToLevel = () => _levelChoice.LoadLevelWithLoadScreen(_levelNumber);
        _button.onClick.AddListener(_goToLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_goToLevel);
    }

    public void SetStars(int starsCount)
    {
        _levelButtonStars.SetStars(starsCount);
    }

    public void BlockLevel()
    {
        //_levelImage.sprite = blockSprite;
        _button.interactable = false;
    }


    // For sorting
    public int CompareTo(object obj)
    {
        if (obj == null)
        {
            return 0;
        }

        LevelButton otherLevel = obj as LevelButton;
        if (otherLevel._levelNumber > _levelNumber)
        {
            return -1;
        }
        if (otherLevel._levelNumber < _levelNumber)
        {
            return 1;
        }
        else return 0;
    }
}
