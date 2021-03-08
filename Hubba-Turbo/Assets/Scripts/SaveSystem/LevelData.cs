using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int[] _levels;

    public int[] Levels
    {
        get { return _levels; }
        set { _levels = value; }
    }
}

