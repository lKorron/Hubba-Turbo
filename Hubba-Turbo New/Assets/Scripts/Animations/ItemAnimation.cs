using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
[RequireComponent(typeof(Animator))]
public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private float delay; // Delay between animations
    [SerializeField] private AnimationClip m_animationClip; // Clip finds name of animation
    [SerializeField] private bool isPlaying = true; // Play or not
    [SerializeField] private bool isRandomFactorActive = true; // Active or not random factor

    private Animator animator;
    private float animationTime = 2.4f; // Time while animation playing
    private string animationName;
    private float randomTime = 0f;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        // Getting name from clip
        animationName = m_animationClip.name;

        StartCoroutine(DelayAnimation());
    }


    private IEnumerator DelayAnimation()
    {
        while (isPlaying)
        {
            // Random factor
            if (isRandomFactorActive)
            {
                randomTime = Random.Range(0, 10);
            } 
            // Our delay
            yield return new WaitForSeconds(delay + randomTime);
            // Start animation
            animator.Play(animationName);
            // Delay = animationTime
            yield return new WaitForSeconds(animationTime);
        }
        
    }
}
