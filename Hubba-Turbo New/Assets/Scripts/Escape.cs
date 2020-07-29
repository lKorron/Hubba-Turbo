using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] private float flyingForce;

    private WeightComparing weightComparing;

    private Rigidbody2D m_rigidbody;
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        weightComparing = GameObject.FindGameObjectWithTag("Platform").GetComponent<WeightComparing>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (weightComparing.IsMouseAndElephant())
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
