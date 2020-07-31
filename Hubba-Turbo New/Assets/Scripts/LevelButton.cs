using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, IComparable
{
    public int levelNumber; // Id for sorting

    // For sorting
    public int CompareTo(object obj)
    {
        if (obj == null)
        {
            return 0;
        }

        LevelButton otherLevel = obj as LevelButton;
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
