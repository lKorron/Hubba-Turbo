using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour, ILevel
{
    [SerializeField] private LevelData _levelData;
    private LevelChoice _levelChoice;
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
        _levelChoice = FindObjectOfType<LevelChoice>();
        print(_levelChoice);

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

    private void TryLoadInterface()
    {
        if (_levelChoice.IsInterfaceLoaded() == false)
        {
            string name = GameScene.Interface.ToString();
            _levelChoice.LoadScene(name);
        }
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
