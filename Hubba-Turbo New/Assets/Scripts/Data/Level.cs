using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour, IComparable
{
    // Fields for images
    [SerializeField] public Sprite oneStarSprite;
    [SerializeField] public Sprite twoStarSprite;
    [SerializeField] public Sprite threeStarSprite;

    [SerializeField] private int countOfStars;

    public int CountOfStars
    {
        get { return countOfStars; }
        private set { countOfStars = value; }
    }

    public int levelNumber;
    // Property for changing sprites in menu
    public Sprite LevelSprite { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    public void SetOneStar()
    {
        LevelSprite = oneStarSprite;
        countOfStars = 1;
    }

    public void SetTwoStar()
    {
        LevelSprite = twoStarSprite;
        countOfStars = 2;
    }

    public void SetThreeStar()
    {
        LevelSprite = threeStarSprite;
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
