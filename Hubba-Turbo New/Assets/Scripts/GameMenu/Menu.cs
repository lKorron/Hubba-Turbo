using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Menu : MonoBehaviour
{
    [SerializeField] private bool _isClearData;
    [SerializeField] private LevelData _levelData;
    [SerializeField] private MenuData _menuData;
    private Level[] _levels; // Don't destroy objets array
    private LevelButton[] _menuLevels; // Menu buttons array
    private SaveSystem _saveSystem;
    private StarsCounter _starsCounter;

    public MenuData MenuData
    { get { return _menuData; }
      set { _menuData = value; }
    }
     

    private void Start()
    {
        _levels = FindObjectsOfType<Level>();
        _menuLevels = FindObjectsOfType<LevelButton>();
        _saveSystem = SaveSystem.Instance;
        _starsCounter = StarsCounter.Instance;

        
        if (_saveSystem.FirstTimeCreate())
            _saveSystem.Save();

        if (_isClearData)
        {
            _saveSystem.DeleteFile();
            _saveSystem.Save();
        }
        else
            _saveSystem.Load();
        

        foreach (var level in _levels)
        {
            if (level != null)
                DataSetUp(level);
        }

        if (_isClearData == false)
            _saveSystem.Save();
        
        

        ShowLevels();
        _levelData.Levels = _menuData.levels;
        _starsCounter.DisplayCollectedStars();
    }

    private void DataSetUp(ILevel level)
    {
        List<int> levelsList = _menuData.levels.ToList();
        bool canProcess = levelsList.Count < _menuLevels.Length;
        
        levelsList[level.LevelNumber - 1] = level.CountOfStars;
        if (level.CountOfStars > 0 && levelsList[levelsList.Count - 1] != 0 && canProcess) // Last element != 0
        {
            levelsList.Add(0);
        }
        _menuData.levels = levelsList.ToArray();

        Destroy(level.gameObject);

        
    }

    private void ShowLevels()
    {
        Array.Sort(_menuLevels);

        int[] levelsWithStars = _menuData.levels;

        for (int i = 0; i < levelsWithStars.Length; i++)
        {
            _menuLevels[i].SetStars(levelsWithStars[i]);
        }
        for (int i = levelsWithStars.Length; i < _menuLevels.Length; i++)
        {
            _menuLevels[i].BlockLevel();
        }
        
    }

    
}
