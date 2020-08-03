using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseItem : MonoBehaviour
{
    private ButtonItem[] buttons;

    private void Start()
    {
        buttons = FindObjectsOfType<ButtonItem>();
    }
    
}
