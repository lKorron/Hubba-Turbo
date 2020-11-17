using System;
using UnityEngine;

public interface ILevel: IComparable
{
    int CountOfStars { get;}
    int LevelNumber { get; }
    GameObject gameObject { get; }
    void SetStars(int count);

}
