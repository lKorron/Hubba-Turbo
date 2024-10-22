﻿using UnityEngine;
using UnityEngine.UI;
 
public class AnimalsPanelCell : MonoBehaviour
{
    [SerializeField] private Image _image;

    private Toggle _toggle;
    private ToggleGroup _toggleGroup;
    private Animal _character;
    private ObjectInstantiate _objectInstantiate;

    public Animal Character => _character;

    private void Start()
    {
        _toggle = GetComponent<Toggle>();
        _toggleGroup = GetComponentInParent<ToggleGroup>();
        _objectInstantiate = FindObjectOfType<ObjectInstantiate>();

        _toggle.group = _toggleGroup;

        _toggle.onValueChanged.AddListener(delegate
        {
            _objectInstantiate.SetCharacter(_character);

        });
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveAllListeners();
    }

    public void Render(IAnimalItem animalItem)
    {
        _image.sprite = animalItem.IconSprite;
        _character = animalItem.Animal;
    }

    public void SetOn()
    {
        _toggle.isOn = true;
    }
}
