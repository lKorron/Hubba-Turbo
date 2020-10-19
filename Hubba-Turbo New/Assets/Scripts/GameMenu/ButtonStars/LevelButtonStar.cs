using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LevelButtonStar : MonoBehaviour
{
    [SerializeField] private Sprite _fillStarSprite;
    [SerializeField] private Sprite _blackStarSprite;
 
    private Image _image;
    
    private void Awake()
    {
        gameObject.SetActive(true);
        _image = GetComponent<Image>();
    }

    public void SetFillStar()
    {
        gameObject.SetActive(true);
        _image.sprite = _fillStarSprite;
    }

    public void SetBlackStar()
    {
        gameObject.SetActive(true);
        _image.sprite = _blackStarSprite;
    }

    public void DeleteStar()
    {
        gameObject.SetActive(false);
    }
   
}
