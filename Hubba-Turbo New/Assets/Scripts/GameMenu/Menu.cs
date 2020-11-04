using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Menu : MonoBehaviour
{
    [SerializeField] private bool IsClearData;
    [SerializeField] private LevelData _levelData;
    [SerializeField] public MenuData menuData;
    private Level[] levels; // Don't destroy objets array
    private LevelButton[] menuLevels; // Menu buttons array
    private SaveSystem saveSystem;

     

    private void Start()
    {
        levels = FindObjectsOfType<Level>();
        menuLevels = FindObjectsOfType<LevelButton>();
        saveSystem = FindObjectOfType<SaveSystem>();

        saveSystem.FirstTimeCreate();

        if (IsClearData)
        {
            saveSystem.DeleteFile();
            saveSystem.Save();
        }
        else saveSystem.Load();
        

        foreach (var level in levels)
        {
            if (level != null)
            {
                DataSetUp(level);
            }
        }

        if (IsClearData == false)
        {
            saveSystem.Save();
        }
        
        

        ShowLevel();
        _levelData.Levels = menuData.levels;
    }
    
    private void DataSetUp(Level level)
    {
        List<int> levelsList = menuData.levels.ToList();
        bool isLevelLast = level.LevelNumber == menuLevels.Length;
        bool canProcess = levelsList.Count < menuLevels.Length;
        
        levelsList[level.LevelNumber - 1] = level.CountOfStars;
        if (level.CountOfStars > 0 && levelsList[levelsList.Count - 1] != 0 && canProcess) // Last element != 0
        {
            levelsList.Add(0);
        }
        menuData.levels = levelsList.ToArray();

        Destroy(level.gameObject);

        
    }

    private void ShowLevel()
    {
        Array.Sort(menuLevels);

        int[] levelsWithStars = menuData.levels;

        for (int i = 0; i < levelsWithStars.Length; i++)
        {
            menuLevels[i].SetStars(levelsWithStars[i]);
        }
        for (int i = levelsWithStars.Length; i < menuLevels.Length; i++)
        {
            menuLevels[i].BlockLevel();
        }
        
    }

    
}
