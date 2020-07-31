using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour, IComparable
{
    [SerializeField] private Sprite levelSprite;
    public int levelNumber;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void SetOneStar()
    {

    }

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
