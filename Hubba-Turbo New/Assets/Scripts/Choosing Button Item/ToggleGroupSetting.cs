using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupSetting : MonoBehaviour
{
    private ToggleGroup toggleGroup;
    private Toggle[] toggles;
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

        toggles = toggleGroup.GetComponentsInChildren<Toggle>();

        toggles[1].isOn = true;

        foreach (var toggle in toggles)
        {
            print(toggle);
        }
    }

}
