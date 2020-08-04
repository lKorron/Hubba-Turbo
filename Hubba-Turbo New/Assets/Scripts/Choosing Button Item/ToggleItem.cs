using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleItem : MonoBehaviour
{
    [SerializeField] private Items character;
    private Toggle toggle;

    public Items Character
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
