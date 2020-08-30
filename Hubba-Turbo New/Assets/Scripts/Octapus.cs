using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octapus : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            print("Platform");
        }
    }

    private void SetPlatformSlippery()
    {

    }
}
