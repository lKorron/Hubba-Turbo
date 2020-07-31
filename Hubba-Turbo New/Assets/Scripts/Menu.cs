using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Level[] levels; // Don't destroy objets array
    [SerializeField] private LevelButton[] menuLevels; // Menu buttons array
    
    

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

        for (int i = 0; i < levels.Length; i++)
        {
            
            menuLevels[i].GetComponent<Image>().sprite = levels[i].levelSprite;
        }
        
    }

    
}
