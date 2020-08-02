using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Menu : MonoBehaviour
{
    [SerializeField] private bool IsClearData;
    [SerializeField] public MenuData menuData;
    private Level[] levels; // Don't destroy objets array
    private LevelButton[] menuLevels; // Menu buttons array
    private List<int> levelsList;
    private SaveSystem saveSystem;

     

    private void Start()
    {
        levels = FindObjectsOfType<Level>();
        menuLevels = FindObjectsOfType<LevelButton>();
        saveSystem = FindObjectOfType<SaveSystem>();

        
        saveSystem.Load();

        foreach (var level in levels)
        {
            if (level != null)
            {
                DataSetUp(level);
            }
        }
        

        saveSystem.Save();
        

        LoadFromData();
    }
    
    private void DataSetUp(Level level)
    {
        levelsList = menuData.levels.ToList();
        //levels.Insert(level.levelNumber - 1, level.CountOfStars);
        levelsList[level.levelNumber - 1] = level.CountOfStars;
        if (level.CountOfStars > 0 && levelsList[levelsList.Count - 1] != 0) // Last element != 0
        {
            levelsList.Add(0);
        }
        menuData.levels = levelsList.ToArray();
        Destroy(level.gameObject);

        
    }

    private void LoadFromData()
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
