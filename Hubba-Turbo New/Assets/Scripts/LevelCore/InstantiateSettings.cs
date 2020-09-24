using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSettings : MonoBehaviour
{
    [Header("Inventory Settings")]
    [SerializeField] private Items _startItemForInstantiate;
    [SerializeField] private List<AnimalItem> _inventoryItems;
    [Header("Computer instantiate Settings")]
    [SerializeField] private InstantiateItem[] _instantiateItems;

    public Items StartItemForInstantiate => _startItemForInstantiate;
    public List<AnimalItem> AnimalItems => _inventoryItems;

    public InstantiateItem[] InstantiateItems => _instantiateItems;

}
