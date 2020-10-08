using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] private int _weight;

    public bool IsCollided { get; set; } = false;
    public int Weight { get; private set; } // property for list processing

    private void Awake()
    {
        Weight = _weight;
    }
    public Item(int weight)
    {
        this.Weight = weight;
    }
    
}
