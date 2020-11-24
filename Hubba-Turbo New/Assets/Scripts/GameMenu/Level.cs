﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour, ILevel
{
    [SerializeField] private LevelData _levelData;
    private int countOfStars;
    private int levelNumber;

    public int CountOfStars
    {
        get { return countOfStars; }
        private set { countOfStars = value; }
    }

    public int LevelNumber { get { return levelNumber; } }
    
    // Property for changing sprites in menu
    public Sprite LevelSprite { get; private set; }

    private void Awake()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(transform.gameObject);


        countOfStars = _levelData.Levels[levelNumber - 1];
        TryLoadInterface();
        
    }

    public void SetOneStar()
    {
        countOfStars = 1;
        _levelData.Levels[levelNumber - 1] = 1;
    }

    public void SetTwoStar()
    {
        countOfStars = 2;
        _levelData.Levels[levelNumber - 1] = 2;
    }

    public void SetThreeStar()
    {
        countOfStars = 3;
        _levelData.Levels[levelNumber - 1] = 3;
    }

    public void SetStars(int count)
    {
        countOfStars = count;
        _levelData.Levels[levelNumber - 1] = count;
    }

    // For array sort
    public int CompareTo(object obj)
    {
        if (obj == null)
        {
            return 0;
        }

        Level otherLevel = obj as Level;
        if (otherLevel.levelNumber > levelNumber)
        {
            return -1;
        }
        if (otherLevel.levelNumber < levelNumber)
        {
            return 1;
        }
        else return 0;
    }

    private void TryLoadInterface()
    {
        if (SceneManager.sceneCount >= 2)
            return;
        string name = GameScene.Interface.ToString();
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

}
