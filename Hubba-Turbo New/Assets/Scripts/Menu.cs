using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Menu : MonoBehaviour
{
     [SerializeField] private MenuData menuData;
     private Level[] levels; // Don't destroy objets array
     private LevelButton[] menuLevels; // Menu buttons array

    private void Start()
    {
        levels = FindObjectsOfType<Level>();
        menuLevels = FindObjectsOfType<LevelButton>();
        
        SetLevelImages();
    }

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

    private void LoadFromData()
    {
        Array.Sort(menuLevels);

        int[] levelsWithStars = menuData.levels;

        foreach (var menuLevel in menuLevels)
        {

        }
    }

    
}
