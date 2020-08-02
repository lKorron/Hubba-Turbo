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
    private Level level; // Don't destroy objets array
    private LevelButton[] menuLevels; // Menu buttons array
    private List<int> levels;
    private SaveSystem saveSystem;

     

    private void Start()
    {
        level = FindObjectOfType<Level>();
        menuLevels = FindObjectsOfType<LevelButton>();
        saveSystem = FindObjectOfType<SaveSystem>();

        
        saveSystem.Load();
        

        if (level != null)
        {
            DataSetUp();
        }

        saveSystem.Save();
        

        LoadFromData();
    }
    /*
    private void SetLevelImages()
    {
        Array.Sort(levels);
        Array.Sort(menuLevels);

        foreach (var level in levels)
        {
            // Get nunber of level
            int levelNumber = level.levelNumber;
            // Find a menu button by number of level
            var menuLevel = menuLevels.SingleOrDefault(item => item.levelNumber == levelNumber);
            // Setting images

            if (level.LevelSprite != null)
            {
                menuLevel.GetComponent<Image>().sprite = level.LevelSprite;

            }
            else return;

        }
        
    }
    */
    private void DataSetUp()
    {
        levels = menuData.levels.ToList();
        //levels.Insert(level.levelNumber - 1, level.CountOfStars);
        levels[level.levelNumber - 1] = level.CountOfStars;
        if (level.CountOfStars > 0 && levels[levels.Count - 1] != 0) // Last element != 0
        {
            levels.Add(0);
        }
        menuData.levels = levels.ToArray();
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
