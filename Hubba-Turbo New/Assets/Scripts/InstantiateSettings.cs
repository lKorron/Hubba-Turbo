using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSettings : MonoBehaviour
{
    [SerializeField] private Items _startItemForInstantiate;
    [SerializeField] private List<GameObject> _computerPrefabList;
    [SerializeField] private List<Vector3> _computerPositionList;

    public Items StartItemForInstantiate { get { return _startItemForInstantiate; } }
    public List<GameObject> ComputerPrefabList { get { return _computerPrefabList; } }
    public List<Vector3> ComputerPositionList { get { return _computerPositionList; } }


}
