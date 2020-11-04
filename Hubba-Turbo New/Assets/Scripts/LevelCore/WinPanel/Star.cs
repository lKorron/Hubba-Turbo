using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    private Image _image;
    private Sprite _starFill;
    private Sprite _starEmpty;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _starFill = Resources.Load<Sprite>("Sprites/UI/Star");
        _starEmpty = _image.sprite;
    }

    public void SetStar()
    {
        _image.sprite = _starFill;
    }

    public void SetEmptyStar()
    {
        _image.sprite = _starEmpty;
    }

    
}
