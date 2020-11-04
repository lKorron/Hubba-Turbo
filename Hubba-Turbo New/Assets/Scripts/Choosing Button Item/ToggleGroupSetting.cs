using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupSetting : MonoBehaviour
{
    private ToggleGroup toggleGroup;
    private AnimalsPanelCell[] panelCells;
    private InstantiateSettings instantiateSettings;
    
    private void Start()
    {
        toggleGroup = FindObjectOfType<ToggleGroup>();
        instantiateSettings = FindObjectOfType<InstantiateSettings>();

        SetToggleGroup();
    }

    private void SetToggleGroup()
    {
        Items currentItem = instantiateSettings.StartItemForInstantiate;

        panelCells = toggleGroup.GetComponentsInChildren<AnimalsPanelCell>();

        foreach (var item in panelCells)
        {
            if (currentItem == item.Character)
            {
                item.SetOn();
            }
        }
    }

}
