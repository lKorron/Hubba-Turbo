using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octapus : MonoBehaviour
{

    private Platform platform;

    private void Start()
    {
        platform = FindObjectOfType<Platform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && platform.IsPlatformSlippery == false)
        {
            platform.SetPlatformSlippery();
        }
    }
}
