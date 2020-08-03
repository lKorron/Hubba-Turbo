using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
public class ButtonItem : MonoBehaviour
{
    [SerializeField] private Sprite clickSprite;
    // Image of chosen item
    private Image image;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
    }

    public void SetItemActive(bool isActive)
    {
        if (isActive)
        {
            image.sprite = clickSprite;
        }
        else image.sprite = null;
    }
}
