using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public bool IsWasCollision { get; private set; } = false;
    // destroy falling objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        IsWasCollision = true;

    }
}
