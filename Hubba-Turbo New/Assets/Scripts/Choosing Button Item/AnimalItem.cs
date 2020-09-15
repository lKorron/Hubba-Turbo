using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AnimalItem")]
public class AnimalItem : ScriptableObject
{
    [SerializeField] private Items _character;
    [SerializeField] private Sprite _iconSprite;

    public Items Character { get { return _character; } }
    public Sprite IconSprite { get { return _iconSprite; } }
}
