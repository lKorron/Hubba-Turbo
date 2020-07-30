using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    // Index for 
    [SerializeField] private int index;
    private Image image;
    private Sprite starFill;

    private void Awake()
    {
        image = GetComponent<Image>();
        starFill = Resources.Load<Sprite>("Sprites/UI/Star");

    }

    public int GetIndex()
    {
        return index;
    }

    public void SetStar()
    {
        
        image.sprite = starFill;
    }
}
