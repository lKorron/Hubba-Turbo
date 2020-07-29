using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private string animationName;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DelayAnimation());
    }

    
    void Update()
    {
        
    }

    private IEnumerator DelayAnimation()
    {
        yield return new WaitForSeconds(delay);
        animator.Play(animationName);
    }
}
