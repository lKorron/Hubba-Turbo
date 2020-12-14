using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSnailType: ScriptableObject
{
    public abstract Sprite Sprite { get; }
    public abstract float TimeScale { get; }
    public abstract Side ActivationSide { get; }

    public abstract void ChangeTime();
}
