using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupSetting : MonoBehaviour
{
    private ToggleGroup toggleGroup;
    private ToggleItem[] toggleItems;
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

        toggleItems = toggleGroup.GetComponentsInChildren<ToggleItem>();

        foreach (var item in toggleItems)
        {
            if (currentItem == item.Character)
            {
                item.SetOn();
            }
        }
    }

}
