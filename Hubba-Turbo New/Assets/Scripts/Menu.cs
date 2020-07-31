using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Level[] levels;

    private void Start()
    {
        levels = FindObjectsOfType<Level>();
        SetLevelImages();
    }

    private void SetLevelImages()
    {
        Array.Sort(levels);
        foreach (var item in levels)
        {
            print(item.levelNumber);
        }
    }

    private void RemoveSameObjects()
    {

    }
}
