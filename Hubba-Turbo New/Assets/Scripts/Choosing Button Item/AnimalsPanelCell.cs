using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalsPanelCell : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Render(AnimalItem animalItem)
    {
        _image.sprite = animalItem.IconSprite;
    }

}
