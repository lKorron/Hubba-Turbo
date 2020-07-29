using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] private float flyingForce;

    private Rigidbody2D m_rigidbody;
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartEscape();
        }
           
    }

    private void StartEscape()
    {
        // multiple for comfortable
        m_rigidbody.gravityScale = flyingForce * -1;
    }

}

public enum Fear
{
    mouse,
    snake,
    bird,
    dog,
    wolf
}
