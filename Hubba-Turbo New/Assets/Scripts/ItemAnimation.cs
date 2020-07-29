using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private float delay; // Delay between animations
    [SerializeField] private AnimationClip m_animationClip;
    [SerializeField] private bool isPlaying = true; // Play or not

    private Animator animator;
    private float animationTime = 2.8f; // Time while animation playing
    private string animationName;
    
    void Start()
    {

        animator = GetComponent<Animator>();

        animationName = m_animationClip.name;
        StartCoroutine(DelayAnimation());
        
    }

    

    private IEnumerator DelayAnimation()
    {
        while (isPlaying)
        {
            yield return new WaitForSeconds(delay);
            animator.Play(animationName);
            yield return new WaitForSeconds(animationTime);
        }
        
    }
}
