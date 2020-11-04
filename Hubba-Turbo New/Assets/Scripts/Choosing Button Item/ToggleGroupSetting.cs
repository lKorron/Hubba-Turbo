using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupSetting : MonoBehaviour
{
    private ToggleGroup _toggleGroup;
    private AnimalsPanelCell[] _panelCells;
    private InstantiateSettings _instantiateSettings;
    
    private void Start()
    {
        _toggleGroup = FindObjectOfType<ToggleGroup>();
        _instantiateSettings = FindObjectOfType<InstantiateSettings>();

        SetToggleGroup();
    }

    private void SetToggleGroup()
    {
        Animal currentItem = _instantiateSettings.StartItemForInstantiate;

        _panelCells = _toggleGroup.GetComponentsInChildren<AnimalsPanelCell>();

        foreach (var item in _panelCells)
        {
            if (currentItem == item.Character)
            {
                item.SetOn();
            }
        }
    }

}
