using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AnimalItem")]
public class AnimalItem : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _iconSprite;

    public Sprite IconSprite { get { return _iconSprite; } }
}
