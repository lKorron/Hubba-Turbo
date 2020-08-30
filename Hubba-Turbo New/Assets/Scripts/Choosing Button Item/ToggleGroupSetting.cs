using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupSetting : MonoBehaviour
{
    private ToggleGroup toggleGroup;
    private ToggleItem[] toggleItems;
    private ObjectInstantiate objectInstantiate;
    
    private void Start()
    {
        toggleGroup = FindObjectOfType<ToggleGroup>();
        objectInstantiate = FindObjectOfType<ObjectInstantiate>();

        SetToggleGroup();
    }

    private void SetToggleGroup()
    {
        Items currentItem = objectInstantiate.StartItemForInstantiate;

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
