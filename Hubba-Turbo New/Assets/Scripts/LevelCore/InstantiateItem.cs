using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AnimalItem")]
public class InstantiateItem : ScriptableObject
{
    [SerializeField] private Items _character;
    [SerializeField] private int _weight;

    public Items Character => _character;
    public int Weight => _weight;

}
