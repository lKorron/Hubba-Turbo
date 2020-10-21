using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour, IComparable
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
        
    }

    public void SetOneStar()
    {
        countOfStars = 1;
    }

    public void SetTwoStar()
    {
        countOfStars = 2;
    }

    public void SetThreeStar()
    {
        countOfStars = 3;
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

}
