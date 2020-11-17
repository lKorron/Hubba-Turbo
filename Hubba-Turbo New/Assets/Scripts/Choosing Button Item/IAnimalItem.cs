using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimalItem
{
    Animal Animal { get; }
    Sprite IconSprite { get; }
}
