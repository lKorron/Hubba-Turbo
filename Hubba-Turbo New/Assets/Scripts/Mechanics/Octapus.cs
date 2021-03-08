using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octapus : MonoBehaviour
{
    private Platform _platform;

    private void Start()
    {
        _platform = Platform.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Platform>() && _platform.IsPlatformSlippery == false)
        {
            _platform.SetPlatformSlippery();
        }
    }
}
