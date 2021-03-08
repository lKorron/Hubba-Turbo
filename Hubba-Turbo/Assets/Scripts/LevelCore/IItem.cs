using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    bool IsCollided { get; set; }
    bool IsRemoved { get; set; }
    bool IsStartItem { get; }
    int Weight { get; }
    GameObject gameObject { get; }

}
