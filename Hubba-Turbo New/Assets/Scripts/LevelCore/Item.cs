using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] private int _weight;
    [SerializeField] private bool _isStartItem;

    public bool IsCollided { get; set; } = false;
    public bool IsRemoved { get; set; } = false;

    public int Weight => _weight; // property for list processing
    public bool IsStartItem => _isStartItem;

    public Item(int weight)
    {
        _weight = weight;
    }
    
}
