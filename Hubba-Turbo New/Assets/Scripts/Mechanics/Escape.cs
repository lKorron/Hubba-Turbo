using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Item))]

public class Escape : MonoBehaviour
{
    [SerializeField] private Animal _selfAnimal;
    [SerializeField] private Animal _fearAnimal;
    [SerializeField] private Side _escapeSide;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _flyingForce; // How fast unit will fly

    private WeightComparing _weightComparing;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Item _itemSelf;
    private ItemCollision[] _itemCollisions;
    private bool _isEscaping;
    private float _animationTime = 2f;
    private float delayAfterAnimation = 4f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _itemSelf = GetComponent<Item>();

        _weightComparing = FindObjectOfType<WeightComparing>();
        _itemCollisions = FindObjectsOfType<ItemCollision>();

        foreach (var item in _itemCollisions)
        {
            item.OnCollision.AddListener(CheckAndEscape);
        }
        

    }

    private void OnDisable()
    {
        foreach (var item in _itemCollisions)
        {
            item.OnCollision.RemoveListener(CheckAndEscape);
        }
    }

    public void CheckAndEscape()
    {
        if (_weightComparing.IsAnimalsOnBoard(_fearAnimal, _selfAnimal) && _isEscaping == false)
        {
            StartCoroutine(StartEscape());
            _weightComparing.RemoveItem(_itemSelf, _escapeSide);
        }
    }

    // Flying method
    private IEnumerator StartEscape()
    {
        _animator.Play("ElephantEscape");
        _isEscaping = true;
        yield return new WaitForSeconds(_animationTime);
        // Multiple for comfortable
        _rigidbody.gravityScale = _flyingForce * -1;
        yield return new WaitForSeconds(delayAfterAnimation);
        _isEscaping = false;
    }

    

}

