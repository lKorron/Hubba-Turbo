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
    private Sprite starEmpty;

    private void Awake()
    {
        image = GetComponent<Image>();
        starFill = Resources.Load<Sprite>("Sprites/UI/Star");
        starEmpty = image.sprite;
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetStar()
    {
        image.sprite = starFill;
    }

    public void SetEmptyStar()
    {
        image.sprite = starEmpty;
    }

    
}
