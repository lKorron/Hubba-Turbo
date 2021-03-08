using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour, ILevel
{
    [SerializeField] private LevelData _levelData;
    private int _countOfStars;
    private int _levelNumber;

    public int CountOfStars
    {
        get { return _countOfStars; }
        private set { _countOfStars = value; }
    }

    public int LevelNumber { get { return _levelNumber; } }
    public bool IsLevelOpenByPlayer => _levelNumber - 1 < _levelData.Levels.Length;

    private void Awake()
    {
        _levelNumber = SceneManager.GetActiveScene().buildIndex;

        if (IsLevelOpenByPlayer)
        {
            DontDestroyOnLoad(transform.gameObject);
            _countOfStars = _levelData.Levels[_levelNumber - 1];
        }

        TryLoadInterface();
        
    }

    public void SetStars(int count)
    {
        if (IsLevelOpenByPlayer)
        {
            _countOfStars = count;
            _levelData.Levels[_levelNumber - 1] = count;
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

    private void TryLoadInterface()
    {
        if (SceneManager.sceneCount >= 2)
            return;
        string name = GameScene.Interface.ToString();
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

}
