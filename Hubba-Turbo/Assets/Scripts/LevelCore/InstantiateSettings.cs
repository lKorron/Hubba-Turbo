﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSettings : MonoBehaviour
{
    [Header("Inventory Settings")]
    [SerializeField] private Animal _startItemForInstantiate;
    [SerializeField] private List<AnimalItem> _inventoryItems;
    [Header("Computer instantiate Settings")]
    [SerializeField] private InstantiateItem[] _instantiateItems;

    public Animal StartItemForInstantiate => _startItemForInstantiate;
    public List<AnimalItem> AnimalItems => _inventoryItems;
    public InstantiateItem[] InstantiateItems => _instantiateItems;
    public static InstantiateSettings Instance { get; private set; }

    #region OnValidate
    private void OnValidate()
    {
        foreach (var item in _instantiateItems)
        {
            if (item.PrefabsNumber < 1)
                item.SetStandartPrefabNumber();
            if (item.Prefab.GetComponent<Item>() == false)
            {
                item.ClearPrefab();
                Debug.Log("Please use correct prefab");
            }
        }
    }
    #endregion

    private void Awake()
    {
        Instance = this;
    }
}
