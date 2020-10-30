using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AnimalItem")]
public class AnimalItem : ScriptableObject
{
    [SerializeField] private Animal _animal;
    [SerializeField] private Sprite _iconSprite;

    public Animal Animal { get { return _animal; } }
    public Sprite IconSprite { get { return _iconSprite; } }
}
