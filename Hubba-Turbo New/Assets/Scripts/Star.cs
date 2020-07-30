using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Index for 
    [SerializeField] private int index;
    private Sprite starFill;

    public int GetIndex()
    {
        return index;
    }
}
