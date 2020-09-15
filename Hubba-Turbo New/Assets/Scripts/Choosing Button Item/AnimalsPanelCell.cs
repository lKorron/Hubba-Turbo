using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnimalsPanelCell : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Toggle _toggle;
    private ToggleGroup _toggleGroup;
    private Items _character;
    private ObjectInstantiate _objectInstantiate;

    public Items Character { get { return _character; } }

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
    public void Render(AnimalItem animalItem)
    {
        _image.sprite = animalItem.IconSprite;
        _character = animalItem.Character;
    }
    public void SetOn()
    {
        _toggle.isOn = true;
    }

}
