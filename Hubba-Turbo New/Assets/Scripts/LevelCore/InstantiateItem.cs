using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InstantiateItem
{

    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _prefabsNumber;
    [SerializeField] private Vector3 _position;

    public GameObject Prefab => _prefab;
    public int PrefabsNumber => _prefabsNumber;
    public Vector3 Position => _position;

    public void SetStandartPrefabNumber()
    {
        _prefabsNumber = 1;
    }

}
