using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
[RequireComponent(typeof(Animator))]
public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private float _delay; // Delay between animations
    [SerializeField] private AnimationClip _animationClip; // Clip finds name of animation
    [SerializeField] private bool _isPlaying = true; // Play or not
    [SerializeField] private bool _isRandomFactorActive = true; // Active or not random factor

    private Animator _animator;
    private float _animationTime = 2.4f; // Time while animation playing
    private string _animationName;
    private float _randomTime = 0f;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        // Getting name from clip
        _animationName = _animationClip.name;
 
        StartCoroutine(DelayAnimation());
    }


    private IEnumerator DelayAnimation()
    {
        while (_isPlaying)
        {
            // Random factor
            if (_isRandomFactorActive)
            {
                _randomTime = Random.Range(0, 10);
            } 
            // Our delay
            yield return new WaitForSeconds(_delay + _randomTime);
            // Start animation
            _animator.Play(_animationName);
            // Delay = animationTime
            yield return new WaitForSeconds(_animationTime);
        }
        
    }
}
