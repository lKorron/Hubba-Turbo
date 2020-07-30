﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] private float flyingForce; // How fast unit will fly

    private WeightComparing weightComparing;
    private Rigidbody2D m_rigidbody;
    private Animator animator;
    private float animationTime = 2f;
    private float delayAfterAnimation = 2f;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        weightComparing = FindObjectOfType<WeightComparing>();
        animator = GetComponent<Animator>();
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CheckAndEscape();
    }

    public void CheckAndEscape()
    {
        if (weightComparing.IsMouseAndElephant())
        {
            StartCoroutine(StartEscape());
        }
    }

    // Flying method
    private IEnumerator StartEscape()
    {
        animator.Play("ElephantEscape");

        yield return new WaitForSeconds(animationTime);
        // Multiple for comfortable
        m_rigidbody.gravityScale = flyingForce * -1;
        yield return new WaitForSeconds(delayAfterAnimation);
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
