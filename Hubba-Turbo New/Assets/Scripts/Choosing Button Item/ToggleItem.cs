using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Old Class
public class ToggleItem : MonoBehaviour
{
    [SerializeField] private Animal character;
    private Toggle toggle;

    public Animal Character
    {
        get { return character; }
    }

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public void SetOn()
    {
        toggle.isOn = true;
    }


}
