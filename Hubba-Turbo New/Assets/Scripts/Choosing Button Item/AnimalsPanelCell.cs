using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalsPanelCell : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Toggle _toggle;
    private ToggleGroup _toggleGroup;

    private void Start()
    {
        _toggle = GetComponent<Toggle>();
        _toggleGroup = GetComponentInParent<ToggleGroup>();

        _toggle.group = _toggleGroup;
    }
    public void Render(AnimalItem animalItem)
    {
        _image.sprite = animalItem.IconSprite;
    }
    public void SetOn()
    {
        _toggle.isOn = true;
    }

}
