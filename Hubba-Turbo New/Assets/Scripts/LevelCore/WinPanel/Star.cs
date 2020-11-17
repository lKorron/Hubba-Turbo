using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [SerializeField] private Sprite _starFill;
    private Image _image;
    private Sprite _starEmpty;

    private void Awake()
    {
        _image = GetComponent<Image>();
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
